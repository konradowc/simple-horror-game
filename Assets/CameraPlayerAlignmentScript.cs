using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerAlignmentScript : MonoBehaviour
{
    public Transform playerPos;

    void Update()
    {
        transform.position = playerPos.position;
    }
}
