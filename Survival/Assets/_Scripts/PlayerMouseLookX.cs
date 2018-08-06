using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseLookX : MonoBehaviour
{

    float MouseX;
    bool lockCursor = true;
    public float sensitivityX = 2f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (lockCursor)
            {
                lockCursor = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else if (!lockCursor)
            {
                lockCursor = true;
                Cursor.visible = false;
            }
        }
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        MouseX = Input.GetAxis("Mouse X");

        Vector3 newRotation = transform.localEulerAngles;
        newRotation.y += MouseX * sensitivityX;
        transform.localEulerAngles = newRotation;
    }
}
