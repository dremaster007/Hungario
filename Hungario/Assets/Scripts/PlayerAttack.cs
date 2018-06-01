using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public CapsuleCollider2D axeHitCollider;
    public StatManager statManager;

    public int hitDamage;

    public void Start()
    {
        axeHitCollider = GetComponentInChildren<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        #region Swinging Weapon Animation
        if (Input.GetButton("Fire1"))
        {
            animator.SetBool("isSwinging", true);
        }

        if (!Input.GetButton("Fire1"))
        {
            hitDamage = 0;
            animator.SetBool("isSwinging", false);
        }
        #endregion
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Collided with the " + other.gameObject.name);

        if (other.gameObject.name == "PlayerTDS")
        {
            hitDamage = 10;
            return;
        }

        if (other.gameObject.name == "Tree-Large" && Input.GetButton("Fire1"))
        {
            hitDamage = 1;
            statManager.TextChange();
            //StartCoroutine(SwingHit());
        }
    }

    /*IEnumerator SwingHit()
    {
        hitDamage = 5;
        Debug.Log("Hit");
        yield return new WaitForSeconds(.4f);
    }*/
}
