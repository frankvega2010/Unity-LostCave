using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGoToScene : MonoBehaviour
{
    public string sceneName;

    public void GoToThisScene()
    {
        if(sceneName == "Level")
        {
            LoaderManager.Get().LoadScene(sceneName);
            UILoadingScreen.Get().SetVisible(true);
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
        
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
