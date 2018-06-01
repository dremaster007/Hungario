using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            animator.SetBool("isSwinging", true);
        }

        if (!Input.GetButton("Fire1"))
        {
            animator.SetBool("isSwinging", false);
        }
    }
}
