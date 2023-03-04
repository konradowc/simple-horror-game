using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public static GameFlow game; // singleton

    public uint newspaperCount = 0;

    private void Awake()
    {
        game = this;
    }

    void Start()
    {
        //Events.events.MonsterSpawn(); // spawn the monster
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
