using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public Text pointsText;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " PUNTOS";
    }

    public void PlayAgainButton()
    {
        SceneManager.LoadScene("FutbolScene");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
