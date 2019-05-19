using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    private int lives;
    private int points;

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

    public void addPoints(int newPoints)
    {
        points = points + newPoints;
    }

    public void subtractPoints(int newPoints)
    {
        points = points - newPoints;
        if (points <= 0)
        {
            points = 0;
        }
    }

    public int getPoints()
    {
        return points;
    }
}
