using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class UIManager
{
    public UIDocument UIDoc;

    private Label m_LevelLabel;
    private Label m_FoodLabel;

    private VisualElement m_GameOverPanel;
    private Label m_GameOverMessage;

    public void UpdateLevel(int level) => m_LevelLabel.text = $" - LEVEL {level} -";

    public void UpdateFood(int food) => m_FoodLabel.text = $"Food : {food}";

    public void ShowGameOverPanel(int level)
    {
        m_GameOverMessage.text = $"GAME OVER!\n\nYou traveled through {level} levels";
        m_GameOverPanel.style.visibility = Visibility.Visible;
    }

    public void HideGameOverPanel() => m_GameOverPanel.style.visibility = Visibility.Hidden;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Init(UIDocument uiDoc)
    {
        UIDoc = uiDoc;
        m_LevelLabel = UIDoc.rootVisualElement.Q<Label>("LevelLabel");
        m_FoodLabel = UIDoc.rootVisualElement.Q<Label>("FoodLabel");
        m_GameOverPanel = UIDoc.rootVisualElement.Q<VisualElement>("GameOverPanel");
        m_GameOverMessage = m_GameOverPanel.Q<Label>("GameOverMessage");
        HideGameOverPanel();
    }
}
