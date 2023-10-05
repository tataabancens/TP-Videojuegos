using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RankingUIElement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _id;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _score;

    public void Init(int id, string name, int score)
    {
        _id.text = id.ToString();
        _name.text = name;
        _score.text = score.ToString();
    }
}
