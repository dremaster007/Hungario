using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    GameObject self;
    public static float bulletMultiplyer;

    private void Start()
    {
        StartCoroutine(Range());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            collision.GetComponent<EnemyAI>().Enemyhealth -= 0.2f * bulletMultiplyer;
        }
        if (collision.gameObject.name == "Tree")
        {
            collision.GetComponent<EntityHealth>().health -= 0.2f * bulletMultiplyer;
        }
        if (collision.gameObject.name == "Crate")
        {
            collision.GetComponent<EntityHealth>().health -= 0.2f * bulletMultiplyer;
        }
        if (collision.gameObject.name == "Rock")
        {
            collision.GetComponent<EntityHealth>().health -= 0.2f * bulletMultiplyer;
        }
        if (collision.gameObject.name == "thornBush")
        {
            collision.GetComponent<EntityHealth>().health -= 0.2f * bulletMultiplyer;
        }
        Destroy(self);
    }

    IEnumerator Range()
    {
        yield return new WaitForSeconds(5);
        Destroy(self);
    }
}
