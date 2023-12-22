using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    [SerializeField] private Transform _parentGrid;
    [SerializeField] private GameObject _rankingElementPrefab;
    [SerializeField] private InputWindow _inputWindow;

    private List<RankingModel> _players;
    private List<RankingUIElement> _standings = new List<RankingUIElement>();

    public static RankingManager instance;

    private Database _db;

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;

        //EventsManager.instance.OnGameOver += OnGameOver;
    }
    private void Start()
    {
        if (GameManager._isGameOver)
        {
            _inputWindow.Show("Submit score", "Enter name");
            GameManager.instance.SetGameOverFlag(false);
        }
        _db = new Database();
        DisplayDB();
    }
    public void InsertScore(RankingModel model)
    {
        _db.AddRankingRecord(model);
        DestroyRanking();
        DisplayDB();
    }
    private void DisplayDB()
    {
        _players = _db.GetRankingRecords();


        for (int i = 0; i < _players.Count(); i++)
        {
            RankingModel modelToDisplay = _players[i];
            RankingUIElement rankingElement = Instantiate(_rankingElementPrefab, _parentGrid).GetComponent<RankingUIElement>();
            rankingElement.Init(i + 1, modelToDisplay.Name, modelToDisplay.Score, modelToDisplay.Stadium);
            _standings.Add(rankingElement);
        }
    }

    /*private void OnGameOver(bool isVictory)
    {
        _inputWindow.Show("Submit score", "Enter name");
        GameManager.instance.setGameOverFlag(false);
        
    }*/
    public void ChangeScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void DestroyRanking()
    {
        if(_standings.Count > 0)
        {
            for (int i=0; i< _standings.Count;i++)
            {
                Destroy(_standings[i].gameObject);
            }

            _standings.Clear();
        }
    }
}
