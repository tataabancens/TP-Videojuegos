using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventsManager : MonoBehaviour
{
    static public EventsManager instance;

	#region UNITY_EVENTS
	private void Awake() {
		if (instance != null) Destroy(this);
		instance = this;
	}
	#endregion

	#region GAME_MANAGER_ACTIONS
	public event Action<bool> OnGameOver;
	
	public void CallEventGameOver(bool isVictory) {
		if (OnGameOver != null) OnGameOver(isVictory);
	}
	#endregion
}
