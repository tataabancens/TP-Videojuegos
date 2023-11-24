using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip _victory;
    [SerializeField] private AudioClip _defeat;

    private AudioSource _audioSource;

    #region UNITY_EVENT
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        EventsManager.instance.OnGameOver += OnGameOver;
        EventsManager.instance.OnShoot += OnShoot;
        EventsManager.instance.OnReload += OnReload;
    }
    #endregion

    #region EVENTS
    private void OnGameOver(bool isVictory)
    {
        _audioSource.PlayOneShot(isVictory ? _victory : _defeat);
    }

    private void OnShoot(AudioClip clip) {
        _audioSource.PlayOneShot(clip);
    }

    private void OnReload(AudioClip clip) {
        _audioSource.PlayOneShot(clip);
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        
    }
}
