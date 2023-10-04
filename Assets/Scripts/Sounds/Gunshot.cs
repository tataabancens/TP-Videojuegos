using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Gunshot : MonoBehaviour, IListener
{

    #region PUBLIC_PROPERTIES
    public AudioClip AudioClipGunshot => _audioClipGunshot;
    public AudioClip AudioClipReload => _audioClipReload;
    public AudioSource AudioSource => _audioSource;
    #endregion


    #region PRIVATE_PROPERTIES
    [SerializeField] private AudioClip _audioClipGunshot;
    [SerializeField] private AudioClip _audioClipReload;
    [SerializeField] private AudioSource _audioSource;
    #endregion

    public void InitAudioSource() {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _audioClipGunshot;
    }

    public void PlayOnShot(AudioClip clip) {
        _audioSource.PlayOneShot(clip, 1.5f);
    }

    public void Play() {
        _audioSource.Play();
    }

    public void Stop() {
        _audioSource.Stop();
    }

    public void Start() {
        InitAudioSource();
    }

    public void Update() {
        if(Input.GetMouseButtonDown(0)) PlayOnShot(_audioClipGunshot);
        if(Input.GetKeyDown(KeyCode.R)) PlayOnShot(_audioClipReload);
        // if (Input.GetKeyDown(KeyCode.Alpha2)) Play();
        // if (Input.GetKeyDown(KeyCode.Alpha3)) Stop();
    }
}
