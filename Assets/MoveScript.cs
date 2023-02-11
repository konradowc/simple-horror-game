using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 5f;

    void Update()
    {
        float xMov = Input.GetAxis("Horizontal"); // pressing a or d or <- or ->
        float zMov = Input.GetAxis("Vertical"); // pressing w or s or /\ or \/

        Vector3 move = transform.right * xMov + transform.forward * zMov;
        controller.Move(move * Time.deltaTime * speed);
        controller.transform.position = new Vector3(controller.transform.position.x, 1, controller.transform.position.z);
    }
}
