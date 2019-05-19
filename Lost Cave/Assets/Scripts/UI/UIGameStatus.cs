using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameStatus : MonoBehaviour
{
    public Text gameWalls;
    public GameObject gameManagerObject;

    private GameManager gameManager;
    private int textGameWallsLeft;
    // Start is called before the first frame update
    private void Start()
    {
        gameManager = gameManagerObject.GetComponent<GameManager>();
        textGameWallsLeft = gameManager.getWallsLeft();
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameManager.getWallsLeft() != textGameWallsLeft)
        {
            textGameWallsLeft = gameManager.getWallsLeft();
            updateText(gameWalls, "Walls", textGameWallsLeft);
        }
    }

    public void updateText(Text someText, string nameOfValue, int someValue)
    {
        someText.text = nameOfValue + ": " + someValue;
    }
}
