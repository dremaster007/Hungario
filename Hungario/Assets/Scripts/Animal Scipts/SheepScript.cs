using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepScript : MonoBehaviour {

    public float speed = 2.0f;  // normal spped
    public float scaredSpeed = 4.0f;    // speed when player is too close

    bool scared = false;    // to determine if AI is scared

    void Awake()
    {
        StartCoroutine(StartWalkingRandomly()); // start the random walking
    }

    void Update()
    {
        if (scared) // if scared, walk with normal speed
        {
            transform.Translate(-Vector3.up * scaredSpeed * Time.deltaTime);
        }
        else    // if !scared, run with scared speed
        {
            transform.Translate(-Vector3.up * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D theCollision)
    {
        if(theCollision.gameObject.tag == "Player") // if the player is to close, run and start the timer to stop running
        {
            scared = true;
            StartCoroutine(ScaredTimer());
        }        
    }

    IEnumerator ScaredTimer()   // timer to determine when to stop running
    {
        yield return new WaitForSeconds(3.0f);
        scared = false;
    }

    IEnumerator StartWalkingRandomly()  // random direction walking
    {
        yield return new WaitForSeconds(2.0f);
        Vector3 randomDirection = new Vector3(transform.rotation.x, transform.rotation.y, Random.Range(0f,360f));
        transform.Rotate(randomDirection);
        StartCoroutine(StartWalkingRandomly());
    }

}
