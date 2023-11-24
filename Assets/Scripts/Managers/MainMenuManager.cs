using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Enums;

public class MainMenuManager:MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(Scenes.FutbolScene.ToString());
    }

    public void LoadingScene() {
        SceneManager.LoadScene(Scenes.LoadScene.ToString());
    }

    public void Ranking()
    {
        SceneManager.LoadScene(Scenes.Ranking.ToString());
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
