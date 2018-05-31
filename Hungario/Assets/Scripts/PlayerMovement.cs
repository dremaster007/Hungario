using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed = 0.07f;

    Vector3 velocity = new Vector3(0f, 0f, 0f);

	void Update()
    {
        rotateSprite();
    }

	void FixedUpdate () {
        #region Movement
        if (Input.GetKey(KeyCode.A))
        {
            velocity = transform.position;
            velocity.x -= movementSpeed;
            transform.position = velocity;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity = transform.position;
            velocity.x += movementSpeed;
            transform.position = velocity;
        }
        if (Input.GetKey(KeyCode.W))
        {
            velocity = transform.position;
            velocity.y += movementSpeed;
            transform.position = velocity;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity = transform.position;
            velocity.y -= movementSpeed;
            transform.position = velocity;
        }
        #endregion
    }

    void rotateSprite()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
    }

}
