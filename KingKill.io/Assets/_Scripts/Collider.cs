using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Crate")
        {
            col.transform.GetComponent<EntityHealth>().health -= 0.2f;
        }
        if (col.gameObject.name == "Tree")
        {
            col.transform.GetComponent<EntityHealth>().health -= 0.1f;
        }
        if (col.gameObject.name == "Rock")
        {
            col.transform.GetComponent<EntityHealth>().health -= 0.05f;
        }
    }
}
