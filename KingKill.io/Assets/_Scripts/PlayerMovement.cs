using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Vector2 velocity;
    public float speed;
    int randEntry;
    [SerializeField]
    GameObject Start1;
    [SerializeField]
    GameObject Start2;
    [SerializeField]
    GameObject Start3;
    [SerializeField]
    GameObject Start4;

    // Use this for initialization
    void Start () {
        randEntry = Random.Range(1, 5);
        if (randEntry == 1)
        {
            transform.position = Start1.transform.position;
        }else if (randEntry == 2)
        {
            transform.position = Start2.transform.position;
        }else if (randEntry == 3)
        {
            transform.position = Start3.transform.position;
        }else if (randEntry == 4)
        {
            transform.position = Start4.transform.position;
        }
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
