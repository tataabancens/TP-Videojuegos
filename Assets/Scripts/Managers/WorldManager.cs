using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ammoCounter;
    [SerializeField] private TextMeshProUGUI _stadiumTitle;
    [SerializeField] private GameObject _forceField;

    public static WorldManager instance;

    #region UNITY_EVENTS

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        EventsManager.instance.OnSceneChange += OnSceneChange;
        EventsManager.instance.OnUpdateAmmo += OnUpdateAmmo;
        EventsManager.instance.OnTutorialEnd += OnTutorialEnd;
        EventsManager.instance.OnStadiumReach += OnStadiumReach;
        _stadiumTitle.gameObject.SetActive(false);
    }
    #endregion

    #region ACTIONS
    public void UpdateAmmoCount(int _ammoCount)
    {
        if (_ammoCount == 0)
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

    public void OnUpdateAmmo(int ammo)
    {
        UpdateAmmoCount(ammo);
    }
    public void OnSceneChange(string scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }

    public void OnTutorialEnd(bool tutorialEnd)
    {
        if (tutorialEnd)
        {
            _forceField.SetActive(false);
        }
    }

    public void OnStadiumReach(string stadium, bool stadiumReach)
    {
        if (stadiumReach)
        {
            _stadiumTitle.gameObject.SetActive(true);
        }
        else
        {
            _stadiumTitle.gameObject.SetActive(false);
        }
        _stadiumTitle.text = stadium;
    }

    #endregion
}
