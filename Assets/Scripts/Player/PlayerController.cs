using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private BoardManager m_Board;
    private Vector2Int m_CellPosition;

    public InputAction MoveAction;
    public InputAction StartNewGameAction;

    /// <summary>
    /// Puts the character on the board at the given position.
    /// </summary>
    public void Spawn(BoardManager boardManager, Vector2Int cell)
    {
        m_Board = boardManager;
        MoveTo(cell);
    }

    public void MoveTo(Vector2Int cell)
    {
        m_CellPosition = cell;
        transform.position = m_Board.CellToWorld(m_CellPosition);
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

        var newCellTarget = m_CellPosition;
        if (MoveAction.triggered)
        {
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
                else if (cellData.ContainedObject.PlayerWantsToEnter())
                {
                    MoveTo(newCellTarget);
                    //Call PlayerEntered AFTER moving the player! Otherwise not in cell yet
                    cellData.ContainedObject.PlayerEntered();
                }
            }
        }
    }
}
