using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    GameObject self;
    public static float bulletMultiplyer;
    float bulletHealth = 1;

    private void Start()
    {
        StartCoroutine(Range());
    }

    private void Update()
    {
        bulletMultiplyer = Craft.ammoLevel;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Enemy(Clone)")
        {
            if (PlayerAttack.hasSG)
            {
                collision.GetComponent<EnemyAI>().Enemyhealth -= 1;
                bulletHealth -= Craft.bulletDamage;
            }
            else
            {
                collision.GetComponent<EnemyAI>().Enemyhealth -= (0.4f * bulletMultiplyer);
                bulletHealth -= Craft.bulletDamage;
            }
        }
        if (collision.gameObject.name == "Tree")
        {
            if (PlayerAttack.hasSG)
            {
                collision.GetComponent<EntityHealth>().health -= 1;
                bulletHealth -= Craft.bulletDamage;
            }
            else
            {
                collision.GetComponent<EntityHealth>().health -= (0.4f * bulletMultiplyer);
                bulletHealth -= Craft.bulletDamage;
            }
        }
        if (collision.gameObject.name == "Crate")
        {
            if (PlayerAttack.hasSG)
            {
                collision.GetComponent<EntityHealth>().health -= 1;
                bulletHealth -= Craft.bulletDamage;
            }
            else
            {
                collision.GetComponent<EntityHealth>().health -= (0.4f * bulletMultiplyer);
                bulletHealth -= Craft.bulletDamage;
            }
        }
        if (collision.gameObject.name == "Rock")
        {
            if (PlayerAttack.hasSG)
            {
                collision.GetComponent<EntityHealth>().health -= 1;
                bulletHealth -= Craft.bulletDamage;
            }
            else
            {
                collision.GetComponent<EntityHealth>().health -= (0.4f * bulletMultiplyer);
                bulletHealth -= Craft.bulletDamage;
            }
        }
        if (collision.gameObject.name == "thornBush")
        {
            if (PlayerAttack.hasSG)
            {
                collision.GetComponent<EntityHealth>().health -= 1;
                bulletHealth -= Craft.bulletDamage;
            }
            else
            {
                collision.GetComponent<EntityHealth>().health -= (0.4f * bulletMultiplyer);
                bulletHealth -= Craft.bulletDamage;
            }
        }
        if (bulletHealth < 0)
        {
            Destroy(self);
        }
    }

    IEnumerator Range()
    {
        yield return new WaitForSeconds(5);
        Destroy(self);
    }
}
