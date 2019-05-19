using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerStatus : MonoBehaviour
{
    public Text playerLives;
    public Text playerPoints;
    public GameObject player;

    private PlayerStatus playerStatus;
    private int textPlayerLives;
    private int textPlayerPoints;
    // Start is called before the first frame update
    private void Start()
    {
        playerStatus = player.GetComponent<PlayerStatus>();
        textPlayerLives = playerStatus.getLives();
        textPlayerPoints = playerStatus.getPoints();
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerStatus.getLives() != textPlayerLives)
        {
            textPlayerLives = playerStatus.getLives();
            updateText(playerLives,"Lives", textPlayerLives);
        }

        if (playerStatus.getPoints() != textPlayerPoints)
        {
            textPlayerPoints = playerStatus.getPoints();
            updateText(playerPoints, "Points", textPlayerPoints);
        }
    }

    public void updateText(Text someText,string nameOfValue,int someValue)
    {
        someText.text = nameOfValue + ": " + someValue;
    }
}
