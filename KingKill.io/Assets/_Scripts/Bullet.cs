using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    GameObject self;

    private void Start()
    {
        StartCoroutine(Range());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            collision.GetComponent<EnemyAI>().Enemyhealth -= 0.5f;
        }
        if (collision.gameObject.name == "Tree")
        {
            collision.GetComponent<EntityHealth>().health -= 0.2f;
        }
        if (collision.gameObject.name == "Crate")
        {
            collision.GetComponent<EntityHealth>().health -= 0.4f;
        }
        if (collision.gameObject.name == "Rock")
        {
            collision.GetComponent<EntityHealth>().health -= 0.02f;
        }
        if (collision.gameObject.name == "thornBush")
        {
            collision.GetComponent<EntityHealth>().health -= 1f;
        }
        Destroy(self);
    }

    IEnumerator Range()
    {
        yield return new WaitForSeconds(5);
        Destroy(self);
    }
}
