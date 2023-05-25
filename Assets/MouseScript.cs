using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    public float sensX = 300f;
    public float sensY = 300f;

    public float xRotation = 0f;
    public float yRotation = 0f;

    private bool fullRotation = true;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //Events.events.onBeginningScene += FirstScene;
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
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.smoothDeltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.smoothDeltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
