using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoad : MonoBehaviour
{
    [SerializeField] private string _sceneToLoad;
    private void OnTriggerEnter()
    {
        EventsManager.instance.EventSceneChange(_sceneToLoad);
    }
}
