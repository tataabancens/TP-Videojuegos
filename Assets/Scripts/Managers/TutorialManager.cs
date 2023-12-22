using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject[] popUps;
    private int popUpIndex;

    public static TutorialManager instance;
    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
    }
    void Start()
    {
        EventsManager.instance.OnGoal += OnGoal;
    }
    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < popUps.Length; i++)
        {
            if(i == popUpIndex)
            {
                popUps[popUpIndex].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }
        if(popUpIndex == 0)
        {
            if(Input.GetKeyDown(KeyCode.F1))
            {
                popUpIndex++;
            }
        }
        if (popUpIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                popUpIndex++;
            }
        }
        else if(popUpIndex == 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 3)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 4)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 5)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 6)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                popUps[popUpIndex].SetActive(false);
                popUpIndex = 100;
            }
        }
        else if (popUpIndex == 7)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                popUpIndex++;
            }
        }
    }

    public void OnGoal(int points)
    {
        popUpIndex = 7;
    }
}
