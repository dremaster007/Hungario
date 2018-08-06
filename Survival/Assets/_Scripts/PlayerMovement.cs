using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public static CharacterController player;
    public float speed = 0.006f;
    float gravity = 9.81f;
    float moveFB;
    float moveLR;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveFB = Input.GetAxis("Vertical");
        moveLR = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveFB = moveFB * 1.3f;
            moveFB = moveFB * 1.3f;
        }

        Vector3 movement = new Vector3(moveLR, 0, moveFB);
        Vector3 velocity = movement * speed;
        velocity.y -= gravity;
        velocity = transform.transform.TransformDirection(velocity);
        player.Move(velocity * Time.deltaTime * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            StatsControl.gainHeat = true;
            StatsControl.looseHeat = false;
        }
        if (other.gameObject.tag == "Water")
        {
            StatsControl.gainWater = true;
            StatsControl.looseWater = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            StatsControl.gainHeat = false;
            StatsControl.looseHeat = true;
        }
        if (other.gameObject.tag == "Water")
        {
            StatsControl.gainWater = false;
            StatsControl.looseWater = true;
        }
    }
}
