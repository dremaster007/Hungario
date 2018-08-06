using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBreak : MonoBehaviour {

    public bool shake = false;
    bool shakeDir = false;
    float shakeSize = 0;
    float mult = 1;
    Vector3 startPos;
    Vector3 shakePos;

    public float respawnTime = 10;
    float respawnTimer = 0;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
        shakePos.y = startPos.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (shake)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                shake = false;
            }
            if (shakeDir)
            {
                shakeSize += (0.5f * Time.deltaTime);
                if (shakeSize >= 0.001 * mult)
                {
                    shakeDir = false;
                    mult += 0.1f;
                }
            }
            else if (!shakeDir)
            {
                shakeSize -= (0.5f * Time.deltaTime);
                if (shakeSize <= -0.01f * mult)
                {
                    shakeDir = true;
                    mult += 0.1f;
                }
            }
            if (mult >= 3)
            {
                Materials.stone += Random.Range(35, 65);
                shake = false;
                mult = 1;
                shakeSize = 0;
                transform.GetComponent<Renderer>().enabled = false;
                transform.GetComponent<MeshCollider>().enabled = false;
            }
            shakePos.x = startPos.x + shakeSize;
            shakePos.z = startPos.z + shakeSize;
            transform.position = shakePos;
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
