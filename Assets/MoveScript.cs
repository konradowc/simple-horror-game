using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 5f;

    private bool isGrounded;
    [SerializeField] private LayerMask theGround;

    void Update()
    {
        float xMov = 0;
        float zMov = 0;
        xMov = Input.GetAxis("Horizontal"); // pressing a or d or <- or ->
        zMov = Input.GetAxis("Vertical"); // pressing w or s or /\ or \/

        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.6f, theGround);

        Vector3 move = transform.right * xMov + transform.forward * zMov;
        if(!isGrounded)
        {
            move -= transform.up * 2;
            Debug.Log("not grounded");
        }

        controller.Move(move * Time.deltaTime * speed);
    }
}
