using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseLookY : MonoBehaviour
{

    float MouseY;
    [SerializeField]
    float sensitivityY = 2f;

    // Use this for initialization
    void Start()
    {
        MouseY = 40;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMouseLookX.lockCursor == false)
        {
            return;
        }
        MouseY -= Input.GetAxis("Mouse Y") * sensitivityY;
        MouseY = Mathf.Clamp(MouseY, 0, 80);
        transform.localEulerAngles = new Vector3(MouseY, transform.localEulerAngles.y, 0);
    }
}
