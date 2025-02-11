using UnityEngine;

public class FoodObject : BaseObject
{
    public int AmountGranted = 10;

    /// <summary>
    /// Called when the player enter the cell in which that object is
    /// </summary>
    public override void PlayerEntered()
    {
        Destroy(gameObject);

        //increase food
        GameManager.Instance.ChangeFood(AmountGranted);
        Debug.Log($"Food increased by {AmountGranted}");
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
