using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    private int lives;

    public void addLives()
    {
        lives++;
    }

    public void subtractLives()
    {
        lives--;
        if(lives <= 0)
        {
            lives = 0;
        }
    }

    public int getLives()
    {
        return lives;
    }
}
