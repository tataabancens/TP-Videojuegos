using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    public const float TIME_LIMIT = 30F;

    private float timer = 0F;

    private enum Scenes
    {
        MainMenu,
        FutbolScene,
        GameOver
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.timer += 0.01f;
        Debug.Log("hit");

        // check if it's time to switch scenes
        if (this.timer >= TIME_LIMIT)
        {
            SceneManager.LoadScene(Scenes.GameOver.ToString());
        }
    }
}
