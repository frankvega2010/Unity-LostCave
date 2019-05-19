using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscore : MonoBehaviourSingleton<Highscore>
{
    private int highscore;

    public override void Awake()
    {
        base.Awake();
        highscore = PlayerPrefs.GetInt("highscore", 0);
    }

    public bool save(int newScore)
    {
        if (PlayerPrefs.GetInt("highscore") < newScore)
        {
            PlayerPrefs.SetInt("highscore", newScore);
            PlayerPrefs.Save();
            return true;
        }

        return false;
    }

    public int load()
    {
        return highscore;
    }
}
