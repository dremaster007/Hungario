using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

    bool attacking = false;

    float attackTime = 0;
    float attackCd = 0.3f;

    public Collider2D attackTrigger;

    private void Awake()
    {
        attackTrigger.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && !attacking && !PlayerAttack.isShooting)
        {
            attacking = true;
            attackTime = attackCd;

            attackTrigger.enabled = true;
        }
        if (attacking)
        {
            if (attackTime > 0)
            {
                attackTime -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }
    }
}
