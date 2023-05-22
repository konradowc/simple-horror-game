using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public static GameFlow game; // singleton

    public uint newspaperCount = 0;
    public int carSpeed = 150;

    private void Awake()
    {
        game = this;
    }

    void Start()
    {
        //Invoke("StartBegScene", 0.3f);
        Invoke("StartRegScene", 0.5f);
        
        //Events.events.MonsterSpawn(); // spawn the monster
    }

    public void StartBegScene()
    {
        Events.events.BeginningScene();
    }
    public void StartRegScene()
    {
        Events.events.RegularScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
