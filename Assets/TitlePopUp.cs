using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePopUp : MonoBehaviour
{

    [SerializeField] private string titleUI;

    private void OnTriggerEnter()
    {
        EventsManager.instance.EventStadiumReach(true,titleUI);
    }

    private void OnTriggerExit(Collider other)
    {
        EventsManager.instance.EventStadiumReach(false, titleUI);
    }
}
