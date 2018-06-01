using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarScrolling : MonoBehaviour
{
    public Scrollbar sb;
    public float scroll;

    public void Start()
    {
        sb.GetComponent<Scrollbar>().value = 0;

        scroll = Input.GetAxis("Mouse ScrollWheel");
    }

    public void Update()
    {
        #region Scroll Wheel
        if(Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
        {
            Debug.Log("Scrolling Up.");
            sb.value = sb.value + 0.1f;
        }

        if(Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
        {
            Debug.Log("Scrolling Down.");
            sb.value = sb.value - 0.1f;
        }

        if(Input.GetAxisRaw("Mouse ScrollWheel") > 0 && sb.value == 1f)
        {
            sb.value = 0;
        }

        if(Input.GetAxisRaw("Mouse ScrollWheel") < 0 && sb.value == 0f)
        {
            sb.value = 1;
        }     
        #endregion

        #region Scroll Hotkeys
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            sb.value = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            sb.value = .1f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            sb.value = .2f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            sb.value = .3f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            sb.value = .4f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            sb.value = .51f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            sb.value = .63f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            sb.value = .75f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            sb.value = .87f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            sb.value = .99f;
        }
        #endregion
    }
}
