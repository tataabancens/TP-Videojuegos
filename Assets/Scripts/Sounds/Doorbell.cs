using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorbell : MonoBehaviour, IListener
{
	#region PUBLIC_PROPERTIES
	public AudioClip AudioClip => _audioClip;
    public AudioSource AudioSource => _audioSource;
	#endregion


	#region PRIVATE_PROPERTIES
	[SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioSource _audioSource;
	#endregion

	public void InitAudioSource() {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _audioClip;
    }

    public void PlayOnShot() {
        _audioSource.PlayOneShot(_audioClip);
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
        if(Input.GetKeyDown(KeyCode.Alpha1)) PlayOnShot();
        if (Input.GetKeyDown(KeyCode.Alpha2)) Play();
        if (Input.GetKeyDown(KeyCode.Alpha3)) Stop();
    }
}
