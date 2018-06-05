using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{

    public Animator animator;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Crate")
        {
            if (animator.GetBool("AxeHold") == true)
            {
                col.transform.GetComponent<EntityHealth>().health -= (col.transform.localScale.x / 2) / 3;
                return;
            }
            col.transform.GetComponent<EntityHealth>().health -= (col.transform.localScale.x / 2) / 7;
        }
        if (col.gameObject.name == "Tree")
        {
            if (animator.GetBool("AxeHold") == true)
            {
                col.transform.GetComponent<EntityHealth>().health -= (col.transform.localScale.x / 2) / 3;
                Materials.Wood += Random.Range(2, 4);
            }
            else if (animator.GetBool("AxeHold") == false)
            {
                col.transform.GetComponent<EntityHealth>().health -= (col.transform.localScale.x / 2) / 8;
                Materials.Wood += Random.Range(2, 4);
            }
        }
        if (col.gameObject.name == "Rock")
        {
            if (animator.GetBool("AxeHold") == true)
            {
                return;
            }
            if (animator.GetBool("PickHold") == true)
            {
                col.transform.GetComponent<EntityHealth>().health -= (col.transform.localScale.x / 2) / 3;
                Materials.Stone += Random.Range(3, 5);
                return;
            }
            col.transform.GetComponent<EntityHealth>().health -= (col.transform.localScale.x / 2) / 10;
            Materials.Stone += 1;
        }
        if (col.gameObject.name == "thornBush")
        {
            if (animator.GetBool("AxeHold") == true)
            {
                col.transform.GetComponent<EntityHealth>().health -= (col.transform.localScale.x / 2) / 2;
            }
        }
        if (col.gameObject.name == "Enemy(Clone)")
        {
            if (animator.GetBool("AxeHold") == true)
            {
                col.transform.GetComponent<EnemyAI>().Enemyhealth -= 0.4f;
            }
            else if (animator.GetBool("PickHold") == true)
            {
                col.transform.GetComponent<EnemyAI>().Enemyhealth -= 0.2f;
            }
            else if (animator.GetBool("PuchL") == true || animator.GetBool("PuchR") == true)
            {
                col.transform.GetComponent<EnemyAI>().Enemyhealth -= 0.2f;
            }
        }
    }
}