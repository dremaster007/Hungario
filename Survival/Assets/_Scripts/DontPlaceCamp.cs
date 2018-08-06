using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontPlaceCamp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Solid")
        {
            PlaceCampfire.canPlace = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Solid")
        {
            PlaceCampfire.canPlace = true;
        }
    }
}
