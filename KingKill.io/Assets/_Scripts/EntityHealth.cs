using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour {

    public float health;
    public GameObject Entity;
    public bool canGiveWeapon;

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
                PlayerAttack.hasGun = true;
                PlayerAttack.updateAmmo = true;
            }
        }
	}
}
