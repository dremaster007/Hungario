using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Craft : MonoBehaviour {

    [SerializeField]
    GameObject CraftMenu;
    [SerializeField]
    Button UpWeapon;
    int weaponLevel;
    [SerializeField]
    Button UpPick;
    int pickLevel;
    [SerializeField]
    Button UpAxe;
    int axeLevel;

	// Use this for initialization
	void Start () {
        UpWeapon.onClick.AddListener(upWeapon);
        UpPick.onClick.AddListener(upPick);
        UpAxe.onClick.AddListener(upAxe);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void upWeapon()
    {
        if (weaponLevel == 0)
        {
            if (Materials.Iron > 10 && Materials.Wood > 75)
            {
                weaponLevel++;
                return;
            }
        }
        else if (weaponLevel == 1)
        {
            if (Materials.Iron > 20 && Materials.Wood > 100)
            {
                weaponLevel++;
                return;
            }
        }
    }
    void upPick()
    {
        if (pickLevel == 0)
        {
            if (Materials.Wood > 50 && Materials.Stone > 20)
            {
                pickLevel++;
                return;
            }
        }
        else if (pickLevel == 1)
        {
            if (Materials.Wood > 75 && Materials.Metal > 20)
            {
                pickLevel++;
                return;
            }
        }
    }
    void upAxe()
    {
        if (axeLevel == 0)
        {
            if (Materials.Wood > 50 && Materials.Stone > 20)
            {
                axeLevel++;
                return;
            }
        }
        else if (axeLevel == 1)
        {
            if (Materials.Wood > 75 && Materials.Metal > 20)
            {
                axeLevel++;
                return;
            }
        }
    }
}
