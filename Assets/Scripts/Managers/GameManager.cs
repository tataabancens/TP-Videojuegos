using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _isGameOver = false;
    [SerializeField] private bool _isVictory = false;
    [SerializeField] private float _timerInSeconds = 30f;
    private int _pointsCounter = 0;
    [SerializeField] private TextMeshProUGUI _gameOverMessage;
    [SerializeField]private TextMeshProUGUI _timerCounter;

    #region UNITY_EVENTS
    // Start is called before the first frame update
    void Start()
    {
        EventsManager.instance.OnGameOver += OnGameOver;
        _gameOverMessage.text = string.Empty;
    }
    #endregion

    private void Update()
    {
        if(_timerInSeconds > 0)
        {
            _timerInSeconds -= Time.deltaTime;
        }
        else if(_timerInSeconds < 0)
        {
            _timerInSeconds = 0;
            EventsManager.instance.EventGameOver(true);
        }
        int minutes = Mathf.FloorToInt(_timerInSeconds / 60);
        int seconds = Mathf.FloorToInt(_timerInSeconds % 60);
        if(_timerInSeconds < 30 && _timerInSeconds > 10)
        {
            _timerCounter.color = Color.yellow;
        }else if(_timerInSeconds < 10)
        {
            _timerCounter.color = Color.red;
        }
        _timerCounter.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    #region ACTIONS
    private void OnGameOver(bool isVictory)
    {
        _isGameOver = true;
        _isVictory = isVictory;

        _gameOverMessage.text = isVictory ? "VICTORIA!!" : "DERROTA";
        _gameOverMessage.color = isVictory ? Color.cyan : Color.red;
    }
    #endregion
}
