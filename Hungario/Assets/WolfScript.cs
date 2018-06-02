using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfScript : MonoBehaviour {

    public int attackDamage = 20;

    public float speed = 7f;
    GameObject player;

    public bool playerInRange;

    public void Update()
    {
        if(playerInRange)
        {
            StartCoroutine(ChaseThePlayer(player));
        }
    }

    public void OnTriggerEnter2D(Collider2D theCollision)
    {
        if (theCollision.gameObject.tag == "Player")
        {
            player = theCollision.gameObject;
            playerInRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D theCollision)
    {
        if(theCollision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

    IEnumerator ChaseThePlayer(GameObject theCollision)
    {
        yield return new WaitForSeconds(1f);
        transform.position = Vector3.MoveTowards(transform.position, theCollision.transform.position, speed * Time.deltaTime);
    }
}
