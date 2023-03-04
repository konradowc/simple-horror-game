using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControl : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab;

    private GameObject monster1;
    bool alive = false;

    void Start()
    {
        Events.events.onMonsterSpawn += monsterSpawn;
    }

    private void monsterSpawn()
    {
        monster1 = Instantiate(monsterPrefab, new Vector3(0, 0, 0), transform.rotation);
        monster1.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        alive = true;

        monsterMove();
    }

    private void monsterMove()
    {
        int deltaX;
        int deltaZ;

        while(alive)
        {
            deltaX = 2;
            deltaZ = 2;
            //monster1.transform.position = new Vector3(monster1.transform.position.x + deltaX * Time.deltaTime, 0,
                //monster1.transform.position.z + deltaZ * Time.deltaTime);
        }
    }
}
