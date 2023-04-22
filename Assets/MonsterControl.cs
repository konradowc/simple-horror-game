using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterControl : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab;
    [SerializeField] private Animator animator;

    [SerializeField] private int monsterSpeed = 4;

    private GameObject monster1;
    private State monsterState;
    private double idleTimer = 0;

    private Vector2[] allPosses = {
        new Vector2(0, 0),
        new Vector2(20, 0),
        new Vector2(20, 20),
        new Vector2(20, 50),
        new Vector2(50, 50)
    };
    private Vector2 targetPos;

    private enum State
    {
        PAUSED,
        WALKING,
        IDLE,
        CHASING
    }

    void Start()
    {
        Events.events.onMonsterSpawn += monsterSpawn;

        monsterState = State.PAUSED;
    }

    private void Update()
    {
        if(monsterState == State.WALKING)
        {
            monsterRegularMove();
        }
        else if(monsterState == State.CHASING)
        {
            monsterChaseMove();
        }
    }

    private void monsterSpawn()
    {
        Debug.Log("Spawning monster");
        monster1 = Instantiate(monsterPrefab, new Vector3(0, 0, 0), transform.rotation);
        targetPos = monster1.transform.position; // so that it will choose a new position to go to

        monster1.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        monsterState = State.WALKING;
    }

    private void monsterRegularMove()
    {
        if(targetPos.x == monster1.transform.position.x && targetPos.y == monster1.transform.position.y)
        {
            if (idleTimer == 0)
            {
                monsterState = State.IDLE;
            }

            if (idleTimer <= 2)
                idleTimer += Time.deltaTime;
            else
            {
                idleTimer = 0;
                monsterState = State.WALKING;
            }
        }

        //if(targetPos == monster1.transform.position)
        {
           // targetPos = new Vector3(monster1.transform.position.x + Random.Range(0, 20),
           //  monster1.transform.position.y, monster1.transform.position.z + Random.Range(0, 20));
        }
        //else
        {
           // Vector2 posChange = getChangeInPos();

           // monster1.transform.position = new Vector3(monster1.transform.position.x + monsterSpeed * Time.deltaTime * posChange.x,
                   // monster1.transform.position.y, monster1.transform.position.z + monsterSpeed * Time.deltaTime * posChange.y);
        }
    }

    private void monsterChaseMove()
    {

    }

    private Vector2 getChangeInPos()
    {
        float bigX = targetPos.x - monster1.transform.position.x;
        float bigY = 0; // targetPos.z - monster1.transform.position.z;
        float vectorLength = Mathf.Sqrt(bigX * bigY + bigY * bigY);

        // normalize the vector (divide by length)
        float changeX = bigX / vectorLength;
        float changeY = bigY / vectorLength;

        return new Vector2(changeX, changeY);
    }
}
