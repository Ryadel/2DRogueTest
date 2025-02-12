using UnityEngine;

public class CellObject : MonoBehaviour
{
    protected Vector2Int m_Cell;
    public virtual void Init(Vector2Int cell)
    {
        m_Cell = cell;
    }

    /// <summary>
    /// Called when the player enter the cell in which that object is
    /// </summary>
    public virtual void PlayerEntered()
    {

    }

    public virtual bool PlayerWantsToEnter()
    {
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
