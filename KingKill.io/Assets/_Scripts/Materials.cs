using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Materials : MonoBehaviour {

    public static int Wood = 0;
    [SerializeField]
    Text wood;
    public static int Stone = 0;
    [SerializeField]
    Text stone;
    public static int Metal = 0;
    [SerializeField]
    Text metal;
    public static int Iron = 0;
    [SerializeField]
    Text iron;
    public static int Titanium = 0;
    [SerializeField]
    Text titanium;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		wood.text = "Wood: " + Wood;
        stone.text = "Stone: " + Stone;
        metal.text = "Metal: " + Metal;
        iron.text = "Iron: " + Iron;
        titanium.text = "Titanium: " + Titanium;
        if (Input.GetKeyDown(KeyCode.L))
        {
            Materials.Wood += 100;
            Materials.Stone += 100;
            Materials.Metal += 100;
            Materials.Iron += 100;
            PlayerAttack.gunAmmo += 100;
            PlayerAttack.pistAmmo += 100;
        }
	}
}
