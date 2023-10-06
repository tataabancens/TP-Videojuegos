using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingModel
{
    public string Name => _name;
    public int Score => _score;

    private string _name;
    private int _score;

    public RankingModel(string name, int score)
    {
        _name = name;
        _score = score;
    }

    public string ToString() => $"RankingModel - Name: {Name}, Score: {Score}";
}
