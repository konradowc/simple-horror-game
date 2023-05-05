using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    public float sensX = 900f;
    public float sensY = 900f;

    public float xRotation = 0f;
    public float yRotation = 0f;

    private bool fullRotation = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Events.events.onBeginningScene += FirstScene;
        Events.events.onRegularScene += SecondScene;
    }

    void FirstScene()
    {
        fullRotation = false;
    }

    void SecondScene()
    {
        fullRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        if(!fullRotation)
        {
            xRotation = 0f;
            yRotation = Mathf.Clamp(yRotation, -180f, 0f);
        }

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
