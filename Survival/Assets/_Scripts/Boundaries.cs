using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour {

    public float boundXMax;
    public float boundXMin;
    public float boundZMax;
    public float boundZMin;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > boundXMax)
        {
            transform.position = new Vector3(boundXMax, transform.position.y, transform.position.z);
        }
        if (transform.position.x < boundXMin)
        {
            transform.position = new Vector3(boundXMin, transform.position.y, transform.position.z);
        }
        if (transform.position.z > boundZMax)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, boundZMax);
        }
        if (transform.position.z < boundZMin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, boundZMin);
        }
    }
}
