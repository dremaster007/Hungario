using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Console : MonoBehaviour {

    [SerializeField]
    InputField console = null;

    [SerializeField]
    Button submitButton;

    string value;

	// Use this for initialization
	void Start () {
        submitButton.onClick.AddListener(consoleClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void consoleClick()
    {
        value = console.text;
        if (int.Parse(value) > 0)
        {
            SpawnEnemy.spawnLevel = int.Parse(value);
        }else if (value.ToString() == "give_resources")
        {
            Materials.Wood += 1000;
            Materials.Stone += 1000;
            Materials.Metal += 1000;
            Materials.Iron += 1000;
            PlayerAttack.gunAmmo += 1000;
            PlayerAttack.pistAmmo += 1000;
        }
    }
}
