using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainHealth : MonoBehaviour {

    public float health = 100;

    public float respawnTime = 10;
    float respawnTimer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            transform.GetComponent<Renderer>().enabled = false;
            transform.GetComponent<MeshCollider>().enabled = false;
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
