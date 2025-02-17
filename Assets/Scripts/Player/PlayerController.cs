using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private BoardManager m_Board;
    public Vector2Int CellPosition { get; set; }

    public InputAction MoveAction;
    public InputAction StartNewGameAction;

    public float MoveSpeed = 5.0f;

    private bool m_IsMoving;
    private Vector3 m_MoveTarget;

    private Animator m_Animator;
    private int Animator_Moving = Animator.StringToHash("Moving");
    private int Animator_Attack = Animator.StringToHash("Attack");

    void Awake()
    {
        m_Animator = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameOver)
        {
            if (StartNewGameAction.triggered)
            {
                GameManager.Instance.StartNewGame();
            }
            return;
        }

        if (m_IsMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, m_MoveTarget, MoveSpeed * Time.deltaTime);

            if (transform.position == m_MoveTarget)
            {
                m_IsMoving = false;
                m_Animator.SetBool(Animator_Moving, false);
                var cellData = m_Board.GetCellData(CellPosition);
                if (cellData.ContainedObject != null)
                    cellData.ContainedObject.PlayerEntered();
            }
            return;
        }

        if (MoveAction.triggered)
        {
            var newCellTarget = CellPosition;
            Vector2 move = MoveAction.ReadValue<Vector2>();
            Debug.Log(move);
            //Vector2 position = (Vector2)transform.position + move * 0.1f;
            //transform.position = position;
            newCellTarget.x += (int)move.x;
            newCellTarget.y += (int)move.y;

            //check if the new position is passable, then move there if it is.
            var cellData = m_Board.GetCellData(newCellTarget);
            if (cellData != null && cellData.Passable)
            {
                GameManager.Instance.TickManager.Tick();
                if (cellData.ContainedObject == null)
                {
                    MoveTo(newCellTarget);
                }
                else
                {
                    var canEnter = cellData.ContainedObject.PlayerWantsToEnter();
                    if (canEnter)
                        MoveTo(newCellTarget);
                    else
                        Attack();
                }
            }
        }
    }

    public void Init()
    {
        m_IsMoving = false;
    }

    /// <summary>
    /// Puts the character on the board at the given position.
    /// </summary>
    public void Spawn(BoardManager boardManager, Vector2Int cell)
    {
        m_Board = boardManager;
        MoveTo(cell, smoothMovement: false);
    }

    public void MoveTo(Vector2Int cell, bool smoothMovement = true)
    {
        //technically the player is not there yet, but the movement is only cosmetic
        //and we know nothing can stop it as we checked everything before starting it
        //so safe to update there!
        CellPosition = cell;

        if (smoothMovement)
        {
            m_IsMoving = true;
            m_MoveTarget = m_Board.CellToWorld(CellPosition);
        }
        else
        {
            m_IsMoving = false;
            transform.position = m_Board.CellToWorld(CellPosition);
        }

        m_Animator.SetBool(Animator_Moving, m_IsMoving);
    }

    public void Attack()
    {
        m_Animator.SetTrigger(Animator_Attack);
    }
}
