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
        new Vector2(296, 434),
        new Vector2(260, 454),
        new Vector2(287, 480),
        new Vector2(322, 500),
        new Vector2(384, 515),
        new Vector2(378, 523),
        new Vector2(380, 551),
        new Vector2(407, 552),
        new Vector2(432, 561)
    };
    private int targetPosIndex;

    public float monsterHeight = 5.0f;

    private RaycastHit hit;
    [SerializeField] private LayerMask theGround;

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

        monsterSpawn();
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
        targetPosIndex = Random.Range(0, allPosses.Length);
        monster1 = Instantiate(monsterPrefab, allPosses[targetPosIndex], transform.rotation);

        monster1.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        monsterState = State.WALKING;
    }

    private void monsterRegularMove()
    {
        if (allPosses[targetPosIndex].x == Math.Round(monster1.transform.position.x) && allPosses[targetPosIndex].y == Math.Round(monster1.transform.position.z))
        {
            if(targetPosIndex == 0 || (targetPosIndex < allPosses.Length-1 && Random.Range(0, 2) == 1))
            {
                targetPosIndex++;
            }
            else
            {
                targetPosIndex--;
            }

            // make monster face the right direction
            //monster1.transform.
        }
        else
        {
            // move the monster
            float xMov = (allPosses[targetPosIndex].x - monster1.transform.position.x);
            float zMov = (allPosses[targetPosIndex].y - monster1.transform.position.z);
            Vector3 moveVect = new Vector3(xMov, 0, zMov);
            moveVect = moveVect.normalized;

            Physics.Raycast(transform.position + moveVect, Vector3.down, out hit, theGround); // hit.distance stores distance
            moveVect += Vector3.up * (monsterHeight - hit.distance);

            monster1.transform.position = new Vector3(monster1.transform.position.x + moveVect.x, monster1.transform.position.y + moveVect.y, monster1.transform.position.z + moveVect.z);
        }
    }

    private void monsterChaseMove()
    {

    }
}
