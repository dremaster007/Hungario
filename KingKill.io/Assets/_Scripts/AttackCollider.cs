using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Crate")
        {
            col.transform.GetComponent<EntityHealth>().health -= 0.07f;
        }
        if (col.gameObject.name == "Tree")
        {
            if (PlayerAttack.animator.GetBool("AxeHold") == true)
            {
                col.transform.GetComponent<EntityHealth>().health -= 0.05f;
                Materials.Wood += Random.Range(2, 4);
            }
            else if (PlayerAttack.animator.GetBool("AxeHold") == false)
            {
                col.transform.GetComponent<EntityHealth>().health -= 0.01f;
                Materials.Wood += Random.Range(1, 3);
            }
        }
        if (col.gameObject.name == "Rock")
        {
            if (PlayerAttack.animator.GetBool("AxeHold") == true)
            {
                return;
            }
            col.transform.GetComponent<EntityHealth>().health -= 0.05f;
            Materials.Stone += 1;
        }
    }
}
