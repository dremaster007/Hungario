using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Vector2 velocity;
    public float speed;
    int randEntry;
    public static bool resetPlayerPos = false;
    [SerializeField]
    GameObject Start1;
    [SerializeField]
    GameObject Start2;
    [SerializeField]
    GameObject Start3;
    [SerializeField]
    GameObject Start4;
    [SerializeField]
    GameObject Start5;
    [SerializeField]
    GameObject Start6;
    [SerializeField]
    GameObject Start7;
    [SerializeField]
    GameObject Start8;

    // Use this for initialization
    void Start () {
        randEntry = Random.Range(1, 9);
        Craft.playerLevel = randEntry;
        if (randEntry == 1)
        {
            transform.position = Start1.transform.position;
        }
        else if (randEntry == 2)
        {
            transform.position = Start2.transform.position;
        }
        else if (randEntry == 3)
        {
            transform.position = Start3.transform.position;
        }
        else if (randEntry == 4)
        {
            transform.position = Start4.transform.position;
        }
        else if (randEntry == 5)
        {
            transform.position = Start5.transform.position;
        }
        else if (randEntry == 6)
        {
            transform.position = Start6.transform.position;
        }
        else if (randEntry == 7)
        {
            transform.position = Start7.transform.position;
        }
        else if (randEntry == 8)
        {
            transform.position = Start8.transform.position;
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

        if (resetPlayerPos)
        {
            if (Craft.playerLevel == 1)
            {
                transform.position = Start1.transform.position;
            }
            else if (Craft.playerLevel == 2)
            {
                transform.position = Start2.transform.position;
            }
            else if (Craft.playerLevel == 3)
            {
                transform.position = Start3.transform.position;
            }
            else if (Craft.playerLevel == 4)
            {
                transform.position = Start4.transform.position;
            }
            else if (Craft.playerLevel == 5)
            {
                transform.position = Start5.transform.position;
            }
            else if (Craft.playerLevel == 6)
            {
                transform.position = Start6.transform.position;
            }
            else if (Craft.playerLevel == 7)
            {
                transform.position = Start7.transform.position;
            }
            else if (Craft.playerLevel == 8)
            {
                transform.position = Start8.transform.position;
            }
            resetPlayerPos = false;
        }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
    }
}
