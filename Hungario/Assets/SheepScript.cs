using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepScript : MonoBehaviour {

    float randomSpawningNumber;
    float playerYValue;

    public float speed = 5.0f;

    void Awake()
    {
        StartCoroutine(StartWalkingRandomly());
    }

    void Update()
    {
        transform.Translate(-Vector3.up * Time.deltaTime);
    }
    
    IEnumerator StartWalkingRandomly()
    {
        yield return new WaitForSeconds(2.0f);
        Vector3 randomDirection = new Vector3(transform.rotation.x, transform.rotation.y, Random.Range(1f,360f));
        transform.Rotate(randomDirection);
        StartCoroutine(StartWalkingRandomly());
    }
}
