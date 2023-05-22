using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTextScript : MonoBehaviour
{
    [SerializeField] private GameObject doorText;
    
    void Start()
    {
        Events.events.onEnterDoor += NearDoor;
        Events.events.onExitDoor += AwayFromDoor;

        doorText.SetActive(false);
    }

    private void NearDoor()
    {
        doorText.SetActive(true);
    }

    private void AwayFromDoor()
    {
        doorText.SetActive(false);
    }
}
