using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour {

    public float health;
    public bool canGiveWeapon;
    public bool canGiveIron;
    public bool canRespawn;
    int MaterialType;
    float currentScale;

    private void Start()
    {
        currentScale = transform.localScale.x;
    }

    private void Update()
    {
        transform.localScale = new Vector3(health, health, transform.localScale.z);
        if (health <= (currentScale / 2))
        {
            health = 1;
            transform.GetComponent<SpriteRenderer>().enabled = false;
            if (transform.GetComponent<Collider2D>().GetType() == typeof(BoxCollider2D))
            {
                transform.GetComponent<BoxCollider2D>().enabled = false;
            }
            else if (transform.GetComponent<Collider2D>().GetType() == typeof(PolygonCollider2D))
            {
                transform.GetComponent<PolygonCollider2D>().enabled = false;
            }
            else if (transform.GetComponent<Collider2D>().GetType() == typeof(CircleCollider2D))
            {
                transform.GetComponent<CircleCollider2D>().enabled = false;
            }
            if (canRespawn)
            {
                StartCoroutine(Respawn());
            }
            if (canGiveIron)
            {
                Materials.Iron += 5;
            }
            if (canGiveWeapon)
            {
                if (Craft.weaponLevel == 1)
                {
                    PlayerAttack.pistAmmo += 15;
                }
                else if (Craft.weaponLevel == 2)
                {
                    PlayerAttack.gunAmmo += 30;
                }
                Materials.Metal += 5;
                MaterialType = Random.Range(1, 100);
                if (MaterialType > 0 && MaterialType <= 50)
                {
                    Materials.Wood += Random.Range(25, 41);
                }
                else if (MaterialType > 50 && MaterialType <= 75)
                {
                    Materials.Stone += Random.Range(25, 41);
                }
                else if (MaterialType > 75 && MaterialType <= 85)
                {
                    Materials.Metal += Random.Range(25, 41);
                }
                else if (MaterialType > 85 && MaterialType <= 95)
                {
                    Materials.Iron += Random.Range(25, 41);
                }
                else if (MaterialType > 95 && MaterialType <= 100)
                {
                    Materials.Titanium += Random.Range(25, 41);
                }
            }
        }
    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(30);
        transform.GetComponent<SpriteRenderer>().enabled = true;
        if (transform.GetComponent<Collider2D>().GetType() == typeof(BoxCollider2D))
        {
            transform.GetComponent<BoxCollider2D>().enabled = true;
        }
        else if (transform.GetComponent<Collider2D>().GetType() == typeof(PolygonCollider2D))
        {
            transform.GetComponent<PolygonCollider2D>().enabled = true;
        }
        else if (transform.GetComponent<Collider2D>().GetType() == typeof(CircleCollider2D))
        {
            transform.GetComponent<CircleCollider2D>().enabled = true;
        }
        transform.localScale = new Vector3(1, 1, 1);
    }
}
