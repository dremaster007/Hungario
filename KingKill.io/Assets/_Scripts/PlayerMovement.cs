using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Vector2 velocity;
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Vertical") != 0)
        {
            velocity = transform.position;
            velocity.y += Input.GetAxis("Vertical") * Time.deltaTime * speed;
            transform.position = velocity;
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            velocity = transform.position;
            velocity.x += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            transform.position = velocity;
        }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
    }
}
