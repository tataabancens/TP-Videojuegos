using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InputWindow : MonoBehaviour
{
    [SerializeField]private Button _okButton;
    [SerializeField] private Button _cancelButton;
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TMP_InputField _inputField;
    

    private void Awake()
    {
        Hide();
    }

    public void Show(string titleText, string inputText)
    {
        gameObject.SetActive(true);

        _titleText.text = titleText;
        _inputField.text = inputText;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Cancel()
    {
        Hide();
    }

    public void SubmitScore()
    {
        if(_inputField.text.Length != 0 && _inputField.text.Length < 20)
        {
            int points = GameManager._points;
            RankingModel model = new RankingModel(_inputField.text, points, GameManager.instance._stadium);
            RankingManager.instance.InsertScore(model);
            Hide();
        }
    }
}
