﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    Scrollbar HealthBar;
    [SerializeField]
    Text HealthInd;
    public static float playerHealth = 100;
    int healthRound;
    bool tickDamage = false;
    bool tickDelay = false;
    float lasthealth = playerHealth;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (tickDamage && !tickDelay)
        {
            tickDelay = true;
            StartCoroutine(DamageTick());
        }
        if (playerHealth < 0)
        {
            playerHealth = 100;
            transform.position = new Vector3(0, 0, transform.position.z);
        }
        healthRound = Mathf.RoundToInt(playerHealth);
        HealthInd.text = (healthRound).ToString();
        HealthBar.size = (playerHealth / 100);
        if (lasthealth > playerHealth)
        {
            DmgIndicator.damage = true;
            lasthealth = playerHealth;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "thornBush")
        {
            tickDamage = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "thornBush")
        {
            tickDamage = false;
        }
    }

    IEnumerator DamageTick()
    {
        playerHealth -= 10;
        yield return new WaitForSeconds(0.8f);
        tickDelay = false;
    }
}