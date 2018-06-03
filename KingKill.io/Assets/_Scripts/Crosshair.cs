using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour {

    bool lockCursor = true;

    private void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (lockCursor)
            {
                lockCursor = false;
                Cursor.visible = true;
            }
            else if (!lockCursor)
            {
                Cursor.visible = false;
            }
        }
        transform.position = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
        transform.position = new Vector3(transform.position.x, transform.position.y, -0.7f);
    }
}
