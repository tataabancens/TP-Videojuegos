using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager instance;

    #region UNITY_EVENTS
    private void Awake()
    {
        if (instance != null) Destroy(this);
        instance = this;
    }
    #endregion

    #region GAME_MANAGER_ACTIONS
    public event Action<bool> OnGameOver;
    public void EventGameOver(bool isVictory)
    {
        if (OnGameOver != null) OnGameOver(isVictory);
    }

    public event Action<int> OnGoal;

    public void EventGoal(int points) {
        if (OnGoal != null) OnGoal(points);
	}

    public event Action<AudioClip> OnShoot;

    public void EventShoot(AudioClip clip) {
        if (OnShoot != null) OnShoot(clip);
    }

    public event Action<AudioClip> OnReload;

    public void EventReload(AudioClip clip) {
        if (OnReload != null) OnReload(clip);
    }
    #endregion
}
