using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour {

    public float health;
    public GameObject Entity;
    public bool canGiveWeapon;
    int WeaponType;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector3(health, health, transform.localScale.z);
        if (health <= 0.3f)
        {
            Destroy(Entity);
            if (canGiveWeapon)
            {
                WeaponType = Random.Range(1, 3);
                if (WeaponType == 1)
                {
                    PlayerAttack.hasGun = true;
                    PlayerAttack.updateGunAmmo = true;
                }
                if (WeaponType == 2)
                {
                    PlayerAttack.hasPistol = true;
                    PlayerAttack.updatePistolAmmo = true;
                }
            }
        }
	}
}
