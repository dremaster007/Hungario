using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    public bool isColliding;

    public CapsuleCollider2D axeHitCollider;

    private void Start()
    {
        axeHitCollider = GetComponentInChildren<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        StartCoroutine(CheckSwing());

        #region Swinging Weapon Animation
        if (Input.GetButton("Fire1"))
        {       
            animator.SetBool("isSwinging", true);
        }

        if (!Input.GetButton("Fire1"))
        {
            animator.SetBool("isSwinging", false);
        }
        #endregion
    }

    public void OnTriggerEnter(Collision2D other)
    {
        Debug.Log("Hit the " + other.gameObject.name);

        if (other.gameObject.name == "PlayerTDS")
        {
            return;
        }

        if (other.gameObject.name == "Tree-Large")
        {
            Debug.Log("Hit tree");
        }
    }

    IEnumerator CheckSwing()
    {
        yield return new WaitForSeconds(.4f);
    }
}
