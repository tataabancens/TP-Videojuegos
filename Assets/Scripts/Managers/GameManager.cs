using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public static bool _isGameOver = false;
    [SerializeField] private bool _isVictory = false;
    public bool _tutorialEnd = false;
    private bool _timerStarted = false;
    [SerializeField] private float _timerInSeconds = 30f;
    [SerializeField] public string _stadium;
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
        EventsManager.instance.OnUpdateAmmo += OnUpdateAmmo;
        EventsManager.instance.OnTimerStarted += OnTimerStarted;
        EventsManager.instance.OnTutorialEnd += OnTutorialEnd;

        _gameOverMessage.text = string.Empty;
        _points = 0;
        if(_stadium != null)
        {
            _timerStarted = true;
        }
    }
    #endregion

    private void Update()
    {
        if (_stadium != null)
        {
            _timerStarted = true;
        }
        if (_timerStarted)
        {
            OnTimerUpdate();
            _pointsCounter.text = _points.ToString();
        }   
    }

    #region ACTIONS
    private void OnGameOver(bool isVictory)
    {
        _isGameOver = true;
        _isVictory = isVictory;

        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Ranking");
    }

    private void OnTutorialEnd(bool tutorialEnd)
    {
        _tutorialEnd = tutorialEnd;
    }
    private void OnTimerStarted(bool startTimer)
    {
        _timerStarted = startTimer;
    }

    public void SetGameOverFlag(bool flag) => _isGameOver = flag;
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

    private void OnUpdateAmmo(int ammo)
    {
        UpdateAmmoCount(ammo);
    }
    private void OnGoal(int points) {
        if (_timerStarted)
        {
            _points += points;
        }
	}
    #endregion
}
