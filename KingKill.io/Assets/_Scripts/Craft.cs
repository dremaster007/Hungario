using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Craft : MonoBehaviour {

    [SerializeField]
    GameObject CraftMenu;
    [SerializeField]
    Button UpWeapon;
    public static int weaponLevel;
    [SerializeField]
    Button UpAmmo;
    [SerializeField]
    Text UpAmmoText;
    int ammoLevel;
    [SerializeField]
    Button UpAxe;
    int axeLevel;
    bool toggle = true;

	// Use this for initialization
	void Start () {
        UpWeapon.onClick.AddListener(upWeapon);
        UpAmmo.onClick.AddListener(upAmmo);
        UpAxe.onClick.AddListener(upAxe);
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (toggle)
            {
                CraftMenu.SetActive(true);
                Cursor.visible = true;
                toggle = false;
            }else if (!toggle)
            {
                CraftMenu.SetActive(false);
                Cursor.visible = false;
                toggle = true;
            }
        }
	}

    void upWeapon()
    {
        if (weaponLevel == 0)
        {
            if (Materials.Metal >= 10 && Materials.Wood >= 75)
            {
                PlayerAttack.hasPistol = true;
                PlayerAttack.pistAmmo += 15;
                Materials.Wood -= 75;
                Materials.Metal -= 10;
                weaponLevel = 1;
                return;
            }
        }
        else if (weaponLevel == 1)
        {
            if (Materials.Iron >= 50 && Materials.Wood >= 300)
            {
                PlayerAttack.hasGun = true;
                PlayerAttack.gunAmmo += 30;
                Materials.Iron -= 50;
                Materials.Wood -= 300;
                weaponLevel = 2;
                return;
            }
        }
    }
    void upAmmo()
    {
        if (ammoLevel == 0)
        {
            if (Materials.Metal >= (50 * (ammoLevel + 1)) && Materials.Iron >= (50 * (ammoLevel + 1)))
            {
                Materials.Metal -= (50 * (ammoLevel + 1));
                Materials.Iron -= (50 * (ammoLevel + 1));
                ammoLevel++;
                UpAmmoText.text = "Upgrade Bullet Lv." + (ammoLevel + 1).ToString();
                return;
            }
        }
        else if (ammoLevel == 1)
        {
            if (Materials.Metal >= (50 * (ammoLevel + 1)) && Materials.Iron >= (50 * (ammoLevel + 1)))
            {
                Materials.Metal -= (50 * (ammoLevel + 1));
                Materials.Iron -= (50 * (ammoLevel + 1));
                ammoLevel++;
                UpAmmoText.text = "Upgrade Bullet Lv." + (ammoLevel + 1).ToString();
                return;
            }
        }
        else if (ammoLevel == 2)
        {
            if (Materials.Metal >= (50 * (ammoLevel + 1)) && Materials.Iron >= (50 * (ammoLevel + 1)))
            {
                Materials.Metal -= (50 * (ammoLevel + 1));
                Materials.Iron -= (50 * (ammoLevel + 1));
                ammoLevel++;
                UpAmmoText.text = "Upgrade Bullet Lv." + (ammoLevel + 1).ToString();
                return;
            }
        }
        else if (ammoLevel == 3)
        {
            if (Materials.Metal >= (50 * (ammoLevel + 1)) && Materials.Iron >= (50 * (ammoLevel + 1)))
            {
                Materials.Metal -= (50 * (ammoLevel + 1));
                Materials.Iron -= (50 * (ammoLevel + 1));
                ammoLevel++;
                UpAmmoText.text = "Upgrade Bullet Lv." + (ammoLevel + 1).ToString();
                return;
            }
        }
        else if (ammoLevel == 4)
        {
            if (Materials.Metal >= (50 * (ammoLevel + 1)) && Materials.Iron >= (50 * (ammoLevel + 1)))
            {
                Materials.Metal -= (50 * (ammoLevel + 1));
                Materials.Iron -= (50 * (ammoLevel + 1));
                ammoLevel++;
                UpAmmoText.text = "Upgrade Bullet Lv." + (ammoLevel + 1).ToString();
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
