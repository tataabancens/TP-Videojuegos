using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IListener
{
    AudioClip AudioClipGunshot {
        get;
    }
    AudioClip AudioClipReload
    {
        get;
    }
    AudioSource AudioSource {get;}

    void InitAudioSource();
    void PlayOnShot(AudioClip clip);
    void Play();
    void Stop();
}
