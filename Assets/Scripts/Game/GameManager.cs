using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private int m_CurrentLevel = 0;

    public static GameManager Instance { get; private set; }

    public BoardManager BoardManager;
    public UIManager UIManager;
    public PlayerController PlayerController;
    public UIDocument UIDoc;

    public Vector2Int PlayerCellPosition => PlayerController.CellPosition;

    public TickManager TickManager { get; private set; }

    public int FoodAmount = 100;
    private int m_CurrentFoodAmount;

    public bool IsGameOver { get; set; } = false;

    public CellData Cell { get; set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TickManager = new TickManager();
        TickManager.OnTick += OnTickHappen;

        UIManager = new UIManager();
        UIManager.Init(UIDoc);

        StartNewGame();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartNewGame()
    {
        IsGameOver = false;
        m_CurrentLevel = 0;
        m_CurrentFoodAmount = FoodAmount;
        PlayerController.Init();
        PlayerController.MoveAction.Enable();
        PlayerController.StartNewGameAction.Disable();
        UIManager.HideGameOverPanel();
        NewLevel();
        UIManager.UpdateFood(FoodAmount);
    }

    public void NewLevel()
    {
        BoardManager.Clean();
        BoardManager.Init();
        PlayerController.Spawn(BoardManager, new Vector2Int(1, 1));
        m_CurrentLevel++;
        UIManager.UpdateLevel(m_CurrentLevel);
    }

    void OnTickHappen()
    {
        ChangeFood(-1);
    }

    public void ChangeFood(int amount)
    {
        m_CurrentFoodAmount += amount;
        UIManager.UpdateFood(m_CurrentFoodAmount);
        Debug.Log("Current amount of food : " + m_CurrentFoodAmount);
        if (m_CurrentFoodAmount <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        IsGameOver = true;
        PlayerController.MoveAction.Disable();
        PlayerController.StartNewGameAction.Enable();
        UIManager.ShowGameOverPanel(m_CurrentLevel);
    }
}
