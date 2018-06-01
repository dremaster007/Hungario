using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed = 0.07f;

    Vector3 velocity = new Vector3(0f, 0f, 0f);

	void Update()
    {
        RotateSprite();
    }

	void FixedUpdate ()
    {
        #region Movement
        if (Input.GetAxisRaw("Horizontal") < 0) //Left
        {
            velocity = transform.position;
            velocity.x -= movementSpeed;
            transform.position = velocity;
        }

        if (Input.GetAxisRaw("Horizontal") > 0) //Right
        {
            velocity = transform.position;
            velocity.x += movementSpeed;
            transform.position = velocity;
        }

        if (Input.GetAxisRaw("Vertical") > 0) //Up
        {
            velocity = transform.position;
            velocity.y += movementSpeed;
            transform.position = velocity;
        }

        if (Input.GetAxisRaw("Vertical") < 0) //Down
        {
            velocity = transform.position;
            velocity.y -= movementSpeed;
            transform.position = velocity;
        }
        #endregion
    }

    void RotateSprite()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
    }
}
