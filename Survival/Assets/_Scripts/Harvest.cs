using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvest : MonoBehaviour {

    [SerializeField]
    public Camera cam;
    float range = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                if (hit.transform.name == "Tree")
                {
                    hit.transform.GetComponent<TreeFall>().sway = true;
                }
                else if (hit.transform.name == "Rock")
                {
                    hit.transform.GetComponent<RockBreak>().shake = true;
                }
                else if (hit.transform.name == "Thatch")
                {
                    hit.transform.GetComponent<TerrainHealth>().health -= 100;
                    Materials.wood += Random.Range(8, 12);
                    Materials.thatch += Random.Range(45, 70);
                }
            }
        }
	}
}
