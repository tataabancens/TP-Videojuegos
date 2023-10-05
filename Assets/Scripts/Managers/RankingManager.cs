using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    [SerializeField] private Transform _parentGrid;
    [SerializeField] private GameObject _rankingElementPrefab;

    private List<RankingModel> _players = new List<RankingModel>();
    private List<string> _names;

    private Database _db;
    private void Start()
    {
        _db = new Database();
        _names = new List<string> { "name1", "name2", "name3", "name4", "name5" };
        for (int i = 0; i < 20; i++)
        {
            _db.AddRankingRecord(new RankingModel(i, _names[Random.Range(0, _names.Count)], Random.Range(1, 10000)));
        }
        _players = _db.GetRankingRecords();

        foreach(RankingModel model in _players)
        {
            Debug.Log(model);
            RankingUIElement rankingElement = Instantiate(_rankingElementPrefab, _parentGrid).GetComponent<RankingUIElement>();
            rankingElement.Init(model.ID, model.Name, model.Score);
        }
    }
}
