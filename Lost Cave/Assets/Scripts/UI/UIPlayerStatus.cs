using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerStatus : MonoBehaviour
{
    public Text playerLives;
    public GameObject player;

    private PlayerStatus playerStatus;
    private int textPlayerLives;
    // Start is called before the first frame update
    private void Start()
    {
        playerStatus = player.GetComponent<PlayerStatus>();
        textPlayerLives = playerStatus.getLives();
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerStatus.getLives() != textPlayerLives)
        {
            textPlayerLives = playerStatus.getLives();
            updateText(playerLives,"Lives", textPlayerLives);
        }
    }

    public void updateText(Text someText,string nameOfValue,int someValue)
    {
        someText.text = nameOfValue + ": " + someValue;
    }
}
