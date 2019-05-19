using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameStatus : MonoBehaviour
{
    public Text gameWalls;
    public Text gameEnemies;
    public Text gameTime;
    public GameObject gameManagerObject;

    private GameManager gameManager;
    private int textGameWallsLeft;
    private int textGameEnemies;
    // Start is called before the first frame update
    private void Start()
    {
        gameManager = gameManagerObject.GetComponent<GameManager>();
        textGameWallsLeft = gameManager.getWallsLeft();
        textGameEnemies = gameManager.getEnemiesCount();

        updateText(gameWalls, "Walls", textGameWallsLeft);
        updateText(gameEnemies, "Enemies", textGameEnemies);
    }

    // Update is called once per frame
    private void Update()
    {
        updateText(gameTime, "Time", gameManager.getMatchTime());

        if (gameManager.getWallsLeft() != textGameWallsLeft)
        {
            textGameWallsLeft = gameManager.getWallsLeft();
            updateText(gameWalls, "Walls", textGameWallsLeft);
        }

        if (gameManager.getEnemiesCount() != textGameEnemies)
        {
            textGameEnemies = gameManager.getEnemiesCount();
            updateText(gameEnemies, "Enemies", textGameEnemies);
        }
    }

    public void updateText(Text someText, string nameOfValue, int someValue)
    {
        someText.text = nameOfValue + ": " + someValue;
    }
}
