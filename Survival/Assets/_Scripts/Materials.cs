using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Materials : MonoBehaviour {

    public Text Wood;
    public static int wood = 0;
    public Text Thatch;
    public static int thatch = 0;
    public Text Stone;
    public static int stone = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Wood.text = "Wood: " + wood;
        Thatch.text = "Thatch: " + thatch;
        Stone.text = "Stone: " + stone;
    }
}
