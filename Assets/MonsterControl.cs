using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;
using Random = UnityEngine.Random;

public class MonsterControl : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab;
    [SerializeField] private Animator animator;

    [SerializeField] private GameObject player;

    private GameObject monster1;
    private State monsterState;
    private double idleTimer = 0;

    private Vector2[] allPosses = {
        new Vector2(260, 445),
        new Vector2(280, 487),
        new Vector2(310, 482),
        new Vector2(329, 452),
        new Vector2(368, 480),
        new Vector2(429, 497),
        new Vector2(457, 530)
    };

    private int targetPosIndex;

    public float monsterHeight = 3f;
    public float monsterSpeed = 1f;
    private float visionRange = 50f;

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
        //Events.events.onMonsterSpawn += monsterSpawn;

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
        //targetPosIndex = Random.Range(0, allPosses.Length);
        targetPosIndex = 0;
        monster1 = Instantiate(monsterPrefab, new Vector3(allPosses[targetPosIndex].x, 30, allPosses[targetPosIndex].y), transform.rotation);

        monster1.transform.localScale = new Vector3(3f, 3f, 3f);
        monsterState = State.WALKING;
    }

    private bool monsterVision()
    {
        Vector3 direction = player.transform.position - monster1.transform.position;

        if (direction.magnitude > visionRange)
            return false;

        return !(Physics.Raycast(monster1.transform.position + Vector3.up * 3, direction, out hit, direction.magnitude, theGround)); // nothing in between?
    }

    private void monsterRegularMove()
    {
        if (allPosses[targetPosIndex].x == Math.Round(monster1.transform.position.x) && allPosses[targetPosIndex].y == Math.Round(monster1.transform.position.z))
        {
            Debug.Log("New target");
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
            moveVect = moveVect * 0.02f * monsterSpeed;

            Physics.Raycast(monster1.transform.position + monsterHeight*Vector3.up, Vector3.down, out hit, theGround); // hit.distance stores distance
            moveVect += Vector3.up * (monsterHeight - hit.distance);

            //Debug.Log("Distance: " + hit.distance);
            //Debug.Log("MoveVect.y: " + moveVect.y);

            monster1.transform.position = new Vector3(monster1.transform.position.x + moveVect.x, monster1.transform.position.y + moveVect.y * Time.deltaTime, monster1.transform.position.z + moveVect.z);
            
            double angle = normalizedToAngle(moveVect);
            monster1.transform.eulerAngles = new Vector3(0, (float)angle, 0);

            if(monsterVision())
            {
                Debug.Log("Chasing!" + (player.transform.position - monster1.transform.position).magnitude);
                monsterState = State.CHASING;
                monsterSpeed = 2f;
            }
        }
    }

    private double normalizedToAngle(Vector3 monsterPos)
    {
        double o = (monsterPos.z > 0) ? (monsterPos.z) : (monsterPos.x);
        double a = (monsterPos.z > 0) ? (monsterPos.x) : (monsterPos.z);

        return Math.Atan2(o, a) * (180/Math.PI); // returns angle in degrees
    }

    private void monsterChaseMove()
    {
        float xMov = (player.transform.position.x - monster1.transform.position.x);
        float zMov = (player.transform.position.z - monster1.transform.position.z);
        Vector3 moveVect = new Vector3(xMov, 0, zMov);
        moveVect = moveVect.normalized;
        moveVect = moveVect * 0.1f * monsterSpeed;

        Physics.Raycast(monster1.transform.position + monsterHeight * Vector3.up, Vector3.down, out hit, theGround); // hit.distance stores distance
        moveVect += Vector3.up * (monsterHeight - hit.distance);

        //Debug.Log("Distance: " + hit.distance);
        //Debug.Log("MoveVect.y: " + moveVect.y);

        monster1.transform.position = new Vector3(monster1.transform.position.x + moveVect.x, monster1.transform.position.y + moveVect.y * Time.deltaTime, monster1.transform.position.z + moveVect.z);

        double angle = normalizedToAngle(moveVect);
        monster1.transform.eulerAngles = new Vector3(0, (float)angle, 0);

        if (Math.Round(player.transform.position.x) == Math.Round(monster1.transform.position.x) && Math.Round(player.transform.position.z) == Math.Round(monster1.transform.position.z))
        {
            Debug.Log("Game over!");
            //SceneScript.scenes.Death();
            SceneManager.LoadScene("Died");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (!monsterVision())
        {
            Debug.Log("Walking");
            monsterState = State.WALKING;
            monsterSpeed = 1f;
        }
    }
}
