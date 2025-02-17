using UnityEngine;
using UnityEngine.Tilemaps;

public class ObstacleCellObject : CellObject
{
    public Tile ObstacleTile;
    public Tile DamagedTile;
    public int MaxHealth = 3;

    private int m_HealthPoint;
    private Tile m_OriginalTile;

    public override void Init(Vector2Int cell)
    {
        base.Init(cell);

        m_HealthPoint = MaxHealth;
        m_OriginalTile = GameManager.Instance.BoardManager.GetCellTile(cell);

        GameManager.Instance.BoardManager.SetCellTile(cell, ObstacleTile);
    }

    /// <summary>
    /// Called when the player enter the cell in which that object is
    /// </summary>
    public override void PlayerEntered()
    {

    }

    public override bool PlayerWantsToEnter()
    {
        m_HealthPoint -= 1;

        if (m_HealthPoint == MaxHealth - 1)
        {
            GameManager.Instance.BoardManager.SetCellTile(m_Cell, DamagedTile);
        }

        if (m_HealthPoint > 0)
        {
            return false;
        }

        GameManager.Instance.BoardManager.SetCellTile(m_Cell, m_OriginalTile);
        Destroy(gameObject);
        return true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
