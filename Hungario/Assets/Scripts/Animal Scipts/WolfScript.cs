using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfScript : MonoBehaviour {

    public int attackDamage = 20;

    public float speed = 10f;

    GameObject player;

    public bool playerInRange;

    public void Update()
    {
        if(playerInRange)
        {
            ChaseThePlayer(player);
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

    public void ChaseThePlayer(GameObject theCollision)
    {
        transform.position = Vector3.MoveTowards(transform.position, theCollision.transform.position, speed * Time.deltaTime);
    }
}
