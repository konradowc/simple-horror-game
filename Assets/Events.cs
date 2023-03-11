using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public static Events events;

    private void Awake()
    {
        events = this;
    }

    public event Action onEnterDoor;
    public void EnterDoor() // this method is accessed with the singleton reference, which then calls the action AKA calls onThroughPipe(), which broadcasts the action and the listeners get it
    {
        if (onEnterDoor != null) onEnterDoor();
    }

    public event Action onExitDoor;
    public void ExitDoor()
    {
        if (onExitDoor != null) onExitDoor();
    }

    public event Action onNewspaperGet;
    public void NewspaperGet()
    {
        if (GameFlow.game.newspaperCount == 1) MonsterSpawn();

        if (onNewspaperGet != null) onNewspaperGet();
    }



    /*
     * monster events
     */

    public event Action onMonsterSpawn;
    public void MonsterSpawn()
    {
        Debug.Log("Spawning monster");
        if (onMonsterSpawn != null) onMonsterSpawn();
    }
}
