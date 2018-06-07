using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepScript : MonoBehaviour {

    float randomSpawningNumber;
    float playerYValue;

    //public GameObject wolfSprite;

    [SerializeField]
    float randomWait;

    public float speed = 5.0f;

    void Awake()
    {
        randomWait = Random.Range(1.0f, 10.0f);
        StartCoroutine(StartWalkingRandomly());
    }

    void Update()
    {
        transform.Translate(-Vector3.up * Time.deltaTime);
    }
    
    IEnumerator StartWalkingRandomly()
    {
        yield return new WaitForSeconds(randomWait);
        Vector3 randomDirection = new Vector3(transform.rotation.x, transform.rotation.y, Random.Range(1f,360f));
        transform.Rotate(randomDirection);

        //wolfSprite.transform.rotation.z = randomDirection.z;
        StartCoroutine(StartWalkingRandomly());
    }
}
