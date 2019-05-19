using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFinishPanel : MonoBehaviour
{
    public GameObject Panel;
    public Text finishText;
    public Text scoreText;

    public Color originalPanelColor;
    public Color invisiblePanelColor;

    private Image UIPanel;
    // Start is called before the first frame update
    void Start()
    {
        UIPanel = Panel.GetComponent<Image>();
        UIPanel.color = invisiblePanelColor;
        scoreText.text = "";
        finishText.text = "";
    }

    public void executeRoundUI(string roundSplashText,Color textColor,int score)
    {
        finishText.text = roundSplashText; // "You Won!"
        finishText.color = textColor; // Color.green
        UIPanel.color = originalPanelColor; // UI: CHANGING PANEL COLOR 
        scoreText.text = "Score: " + score;
    }
}
