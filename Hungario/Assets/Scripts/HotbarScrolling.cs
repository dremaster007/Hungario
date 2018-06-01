using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotKeyNumbers
{
    
}

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
        if(scroll > 0f)
        {
            Debug.Log("Scrolling Up.");
            sb.value++;
        }

        if(scroll < 0f)
        {
            Debug.Log("Scrolling Down.");
            sb.value--;
        }

        if(sb.value > 10)
        {
            sb.value = 0;
        }

        if (sb.value < 0)
        {
            sb.value = 10;
        }
        #endregion
    }
}
