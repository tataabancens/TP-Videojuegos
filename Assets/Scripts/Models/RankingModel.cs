using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingModel
{
    public string Name => _name;

    public string Stadium => _stadium;
    public int Score => _score;

    private string _name;
    private int _score;
    private string _stadium;

    public RankingModel(string name, int score, string stadium)
    {
        _name = name;
        _score = score;
        _stadium = stadium;
    }

    public string ToString() => $"RankingModel - Name: {Name}, Score: {Score}, Stadium:{Stadium}";
}
