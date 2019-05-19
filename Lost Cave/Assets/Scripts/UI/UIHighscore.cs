using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHighscore : MonoBehaviour
{
    public Text highscoreText;

    private Highscore highscore;

    private void Awake()
    {
        highscore = Highscore.Get();
    }

    // Start is called before the first frame update
    private void Start()
    {
        highscoreText.text = "Highscore: " + highscore.load();
    }
}
