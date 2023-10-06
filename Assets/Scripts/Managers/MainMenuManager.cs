using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager:MonoBehaviour
{
    private enum Scenes
    {
        MainMenu,
        FutbolScene,
        Ranking,
        GameOver
    }
    public void StartGame()
    {
        SceneManager.LoadScene(Scenes.FutbolScene.ToString());
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
