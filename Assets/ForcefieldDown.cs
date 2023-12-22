using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcefieldDown : MonoBehaviour
{
    [SerializeField] AudioSource _clip;
    // Start is called before the first frame update
    void Start()
    {
        EventsManager.instance.OnTutorialEnd += OnTutorialEnd;
    }

    private void OnTutorialEnd(bool tutorialEnd)
    {
        _clip.Play();
    }
}
