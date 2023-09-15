using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private enum Scenes
    {
        MainMenu,
        FutbolScene,
        GameOver
    }
    public void StartGame()
    {
        SceneManager.LoadScene(Scenes.FutbolScene.ToString());
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
