using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Vector2 velocity;
    public float speed;
    public static bool resetPlayerPos = false;
    [SerializeField]
    GameObject Start1;

    // Use this for initialization
    void Start () {
        transform.position = Start1.transform.position;
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

        if (resetPlayerPos)
        {
            if (Craft.playerLevel == 1)
            {
                transform.position = Start1.transform.position;
            }
            resetPlayerPos = false;
        }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
    }
}
