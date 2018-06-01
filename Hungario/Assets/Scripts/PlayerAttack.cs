using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject player;
    public Animation swing;

    public bool isSwinging;


    private void Start()
    {
        swing = GetComponent<Animation>();
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire 1"))
        {
            isSwinging = true;
        }

        if (!Input.GetButtonDown("Fire 1"))
        {
            isSwinging = false;
        }
    }
}
