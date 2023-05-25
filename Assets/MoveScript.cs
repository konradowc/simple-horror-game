using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public CharacterController controller;
    public GameObject player;

    public GameObject car;

    private bool mainScene = true;

    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    private float speed;

    public float playerHeight = 2.0f;

    private RaycastHit hit;
    [SerializeField] private LayerMask theGround;

    private void Start()
    {
        //Events.events.onBeginningScene += FirstScene;
        //Events.events.onRegularScene += SecondScene;
        //player.transform.position = new Vector3(300, 10, 290);
        player.transform.position = new Vector3(300, 5, 290);
    }

    private void FirstScene()
    {
        mainScene = false;
        player.transform.position = new Vector3(659.7f, 1.3f, 286.6f);
    }

    private void SecondScene()
    {
        mainScene = true;
        player.transform.position = new Vector3(300, 5, 290);
    }

    void Update()
    {
        float xMov = 0;
        float zMov = 0;
        xMov = Input.GetAxis("Horizontal"); // pressing a or d or <- or ->
        zMov = Input.GetAxis("Vertical"); // pressing w or s or /\ or \/
        Vector3 move = transform.right * xMov + transform.forward * zMov;

        Physics.Raycast(transform.position + move, Vector3.down, out hit, theGround); // hit.distance stores distance
        move += Vector3.up * (playerHeight - hit.distance);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            speed = runSpeed;
        else
            speed = walkSpeed;

        controller.Move(move * Time.deltaTime * speed);
    }
}
