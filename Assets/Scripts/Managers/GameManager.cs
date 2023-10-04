using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _isGameOver = false;
    [SerializeField] private bool _isVictory = false;
    [SerializeField] private TextMeshProUGUI _gameOverMessage;
    private int _points = 0;

    #region UNITY_EVENTS
    // Start is called before the first frame update
    void Start()
    {
        EventsManager.instance.OnGameOver += OnGameOver;
        EventsManager.instance.OnGoal += OnGoal;

        _gameOverMessage.text = string.Empty;
    }
    #endregion

    #region ACTIONS
    private void OnGameOver(bool isVictory)
    {
        _isGameOver = true;
        _isVictory = isVictory;

        _gameOverMessage.text = isVictory ? "VICTORIA!!" : "DERROTA";
        _gameOverMessage.color = isVictory ? Color.cyan : Color.red;
    }

    private void OnGoal(int points) {
        _points += points;
        Debug.Log("Gool desde el game manager, puntos: " + _points);
	}
    #endregion
}
