using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour {

    public float health;
    public bool canGiveWeapon;
    public bool canGiveIron;
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
            Destroy(gameObject);
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
}
