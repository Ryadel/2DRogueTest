using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyCellObject : CellObject
{
    public int Health = 3;
    public int Strength = 3;

    private int m_CurrentHealth;

    private void Awake()
    {
        GameManager.Instance.TickManager.OnTick += TurnHappened;
    }

    private void OnDestroy()
    {
        GameManager.Instance.TickManager.OnTick -= TurnHappened;
    }

    public override void Init(Vector2Int coord)
    {
        base.Init(coord);
        m_CurrentHealth = Health;
    }

    public override bool PlayerWantsToEnter()
    {
        m_CurrentHealth -= 1;

        if (m_CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }

        return false;
    }

    bool MoveTo(Vector2Int coord)
    {
        var board = GameManager.Instance.BoardManager;
        var targetCell = board.GetCellData(coord);

        if (targetCell == null
            || !targetCell.Passable
            || targetCell.ContainedObject != null)
        {
            return false;
        }

        //remove enemy from current cell
        var currentCell = board.GetCellData(m_Cell);
        currentCell.ContainedObject = null;

        //add it to the next cell
        targetCell.ContainedObject = this;
        m_Cell = coord;
        transform.position = board.CellToWorld(coord);

        return true;
    }

    void TurnHappened()
    {
        //We added a public property that return the player current cell!
        var playerCell = GameManager.Instance.PlayerController.CellPosition;

        int xDist = playerCell.x - m_Cell.x;
        int yDist = playerCell.y - m_Cell.y;

        int absXDist = Mathf.Abs(xDist);
        int absYDist = Mathf.Abs(yDist);

        if ((xDist == 0 && absYDist == 1)
            || (yDist == 0 && absXDist == 1))
        {
            //we are adjacent to the player, attack!
            Debug.Log($"Enemy attacks! Food decreased by {Strength}");
            GameManager.Instance.ChangeFood(-Strength);
        }
        else
        {
            if (absXDist > absYDist)
            {
                if (!TryMoveInX(xDist))
                {
                    //if our move was not successful (so no move and not attack)
                    //we try to move along Y
                    TryMoveInY(yDist);
                }
            }
            else
            {
                if (!TryMoveInY(yDist))
                {
                    TryMoveInX(xDist);
                }
            }
        }
    }

    bool TryMoveInX(int xDist)
    {
        //try to get closer in x

        //player to our right
        if (xDist > 0)
        {
            return MoveTo(m_Cell + Vector2Int.right);
        }

        //player to our left
        return MoveTo(m_Cell + Vector2Int.left);
    }

    bool TryMoveInY(int yDist)
    {
        //try to get closer in y

        //player on top
        if (yDist > 0)
        {
            return MoveTo(m_Cell + Vector2Int.up);
        }

        //player below
        return MoveTo(m_Cell + Vector2Int.down);
    }
}
