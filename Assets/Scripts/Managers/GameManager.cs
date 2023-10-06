using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public static bool _isGameOver = false;
    [SerializeField] private bool _isVictory = false;
    [SerializeField] private float _timerInSeconds = 30f;
    public static int _points = 0;
    [SerializeField] private TextMeshProUGUI _gameOverMessage;
    [SerializeField]private TextMeshProUGUI _timerCounter;
    [SerializeField] private TextMeshProUGUI _pointsCounter;
    [SerializeField] private TextMeshProUGUI _ammoCounter;

    public static GameManager instance;

    #region UNITY_EVENTS

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        EventsManager.instance.OnGameOver += OnGameOver;
        EventsManager.instance.OnGoal += OnGoal;

        _gameOverMessage.text = string.Empty;
    }
    #endregion

    private void Update()
    {
        OnTimerUpdate();
        _pointsCounter.text = _points.ToString();
        
    }

    #region ACTIONS
    private void OnGameOver(bool isVictory)
    {
        _isGameOver = true;
        _isVictory = isVictory;

        _gameOverMessage.text = isVictory ? "Victory!!" : "Defeat";
        _gameOverMessage.color = isVictory ? Color.cyan : Color.red;
    }

    public void UpdateAmmoCount(int _ammoCount)
    {
        if(_ammoCount == 0)
        {
            _ammoCounter.text = "RELOAD";
            _ammoCounter.color = Color.red;
        }
        else
        {
            _ammoCounter.text = _ammoCount.ToString();
            _ammoCounter.color = Color.white;
        }
    }
    private void OnTimerUpdate()
    {
        if (_timerInSeconds > 0)
        {
            _timerInSeconds -= Time.deltaTime;
        }
        else if (_timerInSeconds < 0)
        {
            _timerInSeconds = 0;
            EventsManager.instance.EventGameOver(true);
        }
        int minutes = Mathf.FloorToInt(_timerInSeconds / 60);
        int seconds = Mathf.FloorToInt(_timerInSeconds % 60);
        if (_timerInSeconds < 30 && _timerInSeconds > 10)
        {
            _timerCounter.color = Color.yellow;
        }
        else if (_timerInSeconds < 10)
        {
            _timerCounter.color = Color.red;
        }
        _timerCounter.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnGoal(int points) {
        _points += points;
	}
    #endregion
}
