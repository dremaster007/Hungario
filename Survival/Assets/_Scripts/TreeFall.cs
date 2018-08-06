using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFall : MonoBehaviour {

    [SerializeField]
    GameObject Player;
    public bool fallTree = false;
    public bool sway = false;
    float fallSize = 1;
    bool shrink = false;
    public float speed = 5;
    float swaySize = 0;
    bool swayDir = false;
    float mult = 1;

    public float respawnTime = 10;
    float respawnTimer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (sway)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                sway = false;
            }
            if (swayDir)
            {
                swaySize += (0.05f * Time.deltaTime);
                if (swaySize >= 0.02 * mult)
                {
                    swayDir = false;
                    mult += 0.1f;
                }
            }
            else if (!swayDir)
            {
                swaySize -= (0.05f * Time.deltaTime);
                if (swaySize <= -0.02f * mult)
                {
                    swayDir = true;
                    mult += 0.1f;
                }
            }
            transform.rotation = new Quaternion(swaySize, Quaternion.identity.y, swaySize, Quaternion.identity.w);
            if (mult >= 1.5f)
            {
                fallTree = true;
                Materials.wood += Random.Range(80, 120) ;
                mult = 1;
                swaySize = 0;
            }
        }
		if (fallTree)
        {
            if (fallSize >= 1 && shrink == false)
            {
                fallSize += (0.1f * Time.deltaTime) * speed;
                if (fallSize >= 1.1f)
                {
                    shrink = true;
                }
            }
            if (shrink)
            {
                fallSize -= (0.2f * Time.deltaTime) * speed;
                if (fallSize <= 0)
                {
                    transform.GetComponent<Renderer>().enabled = false;
                    transform.GetComponent<MeshCollider>().enabled = false;
                    shrink = false;
                    fallTree = false;
                    fallSize = 1;
                }
            }
            transform.localScale = new Vector3(fallSize, fallSize, fallSize);
        }
        if (transform.GetComponent<Renderer>().enabled == false && transform.GetComponent<MeshCollider>().enabled == false)
        {
            if (respawnTimer < respawnTime)
            {
                respawnTimer += 1 * Time.deltaTime;
            }
            else
            {
                respawnTimer = 0;
                transform.GetComponent<Renderer>().enabled = true;
                transform.GetComponent<MeshCollider>().enabled = true;
            }
        }
    }
}
