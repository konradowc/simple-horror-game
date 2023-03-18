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
        float xMov = Input.GetAxis("Horizontal"); // pressing a or d or <- or ->
        float zMov = Input.GetAxis("Vertical"); // pressing w or s or /\ or \/

        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.5f, theGround);

        Vector3 move = transform.right * xMov + transform.forward * zMov;
        controller.Move(move * Time.deltaTime * speed);

        if(!isGrounded)
            controller.transform.position = new Vector3(controller.transform.position.x, controller.transform.position.y - 0.1f, controller.transform.position.z);
    }
}
