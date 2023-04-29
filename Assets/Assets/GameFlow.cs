using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public static GameFlow game; // singleton

    public uint newspaperCount = 0;
    public float carSpeed = 5;

    private void Awake()
    {
        game = this;
    }

    void Start()
    {
        Invoke("StartBegScene", 0.3f);
        
        //Events.events.MonsterSpawn(); // spawn the monster
    }

    void StartBegScene()
    {
        Events.events.BeginningScene();
    }
    void StartRegScene()
    {
        Events.events.RegularScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
