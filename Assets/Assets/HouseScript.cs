using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour
{
    [SerializeField] public bool newspaperGiven = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Events.events.EnterDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Events.events.ExitDoor();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            //if(Input.GetKeyUp(KeyCode.Space))
            if (Input.GetKey(KeyCode.Space) && !newspaperGiven)
            //if(!newspaperGiven)
            {
                GameFlow.game.newspaperCount++;
                Events.events.NewspaperGet();

                newspaperGiven = true;
            }
        }
    }
}
