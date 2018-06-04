using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerAITestPaul : MonoBehaviour {

    bool tickDamage = false;
    bool delayTick = false;

    private void Update()
    {
        if (tickDamage && !delayTick)
        {
            delayTick = true;
            Debug.Log("HitPlayer");
            StartCoroutine(TickDelay());
        }
    }

    IEnumerator TickDelay()
    {
        yield return new WaitForSeconds(0.5f);
        delayTick = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerTDS")
        {
            tickDamage = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerTDS")
        {
            tickDamage = false;
        }
    }
}
