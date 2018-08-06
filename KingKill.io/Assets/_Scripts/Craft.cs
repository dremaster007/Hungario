using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Craft : MonoBehaviour {

    [SerializeField]
    GameObject crossH;
    [SerializeField]
    GameObject Player;
    [SerializeField]
    GameObject console;
    [SerializeField]
    GameObject CraftMenu;
    [SerializeField]
    Button UpWeapon;
    public static int weaponLevel;
    [SerializeField]
    Button UpAmmo;
    [SerializeField]
    Button ToggleDeathRestart;
    [SerializeField]
    Text toggleRestartText;
    public static bool restartOnDeath = true;
    [SerializeField]
    Text UpAmmoText;
    public static int ammoLevel = 1;
    [SerializeField]
    Button UpAxe;
    int axeLevel;
    bool toggle = true;
    public static int playerLevel = 1;
    public static float bulletDamage = 1;

    [SerializeField]
    Button lv1;
    [SerializeField]
    Button lv2;
    [SerializeField]
    Button lv3;
    [SerializeField]
    Button lv4;
    [SerializeField]
    Button lv5;
    [SerializeField]
    Button lv6;
    [SerializeField]
    Button lv7;
    [SerializeField]
    Button lv8;

    [SerializeField]
    Image select1;
    [SerializeField]
    Image select2;
    [SerializeField]
    Image select3;
    [SerializeField]
    Image select4;
    [SerializeField]
    Image select5;
    [SerializeField]
    Image select6;
    [SerializeField]
    Image select7;
    [SerializeField]
    Image select8;

    // Use this for initialization
    void Start () {
        UpWeapon.onClick.AddListener(upWeapon);
        UpAmmo.onClick.AddListener(upAmmo);
        UpAxe.onClick.AddListener(reset);
        ToggleDeathRestart.onClick.AddListener(toggleReset);
        lv1.onClick.AddListener(level1);
        lv2.onClick.AddListener(level2);
        lv3.onClick.AddListener(level3);
        lv4.onClick.AddListener(level4);
        lv5.onClick.AddListener(level5);
        lv6.onClick.AddListener(level6);
        lv7.onClick.AddListener(level7);
        lv8.onClick.AddListener(level8);
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (toggle)
            {
                crossH.SetActive(false);
                PlayerAttack.canAttack = false;
                console.SetActive(true);
                CraftMenu.SetActive(true);
                Cursor.visible = true;
                toggle = false;
            }else if (!toggle)
            {
                crossH.SetActive(true);
                PlayerAttack.canAttack = true;
                console.SetActive(false);
                CraftMenu.SetActive(false);
                Cursor.visible = false;
                toggle = true;
            }
        }
	}

    void toggleReset()
    {
        if (restartOnDeath)
        {
            restartOnDeath = false;
            toggleRestartText.text = "Restart on Death: False";
        }else if (!restartOnDeath)
        {
            restartOnDeath = true;
            toggleRestartText.text = "Restart on Death: True";
        }
    }

    void resetSelect()
    {
        select1.enabled = false;
        select2.enabled = false;
        select3.enabled = false;
        select4.enabled = false;
        select5.enabled = false;
        select6.enabled = false;
        select7.enabled = false;
        select8.enabled = false;
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
        else if (weaponLevel == 2)
        {
            if (Materials.Iron >= 100 && Materials.Wood >= 600)
            {
                PlayerAttack.hasSG = true;
                bulletDamage = 0.5f;
                PlayerAttack.gunAmmo += 15;
                Materials.Iron -= 100;
                Materials.Wood -= 600;
                weaponLevel = 3;
                return;
            }
        }
    }
    void upAmmo()
    {
        if (ammoLevel == 0)
        {
            if (Materials.Metal >= (25 * (ammoLevel + 1)) && Materials.Iron >= (25 * (ammoLevel + 1)))
            {
                Materials.Metal -= (25 * (ammoLevel + 1));
                Materials.Iron -= (25 * (ammoLevel + 1));
                ammoLevel = 1;
                UpAmmoText.text = "Upgrade Bullet Lv." + (ammoLevel).ToString();
                return;
            }
        }
        else if (ammoLevel == 1)
        {
            if (Materials.Metal >= (25 * (ammoLevel + 1)) && Materials.Iron >= (25 * (ammoLevel + 1)))
            {
                Materials.Metal -= (25 * (ammoLevel + 1));
                Materials.Iron -= (25 * (ammoLevel + 1));
                ammoLevel = 2;
                UpAmmoText.text = "Upgrade Bullet Lv." + (ammoLevel).ToString();
                return;
            }
        }
        else if (ammoLevel == 2)
        {
            if (Materials.Metal >= (25 * (ammoLevel + 1)) && Materials.Iron >= (25 * (ammoLevel + 1)))
            {
                Materials.Metal -= (25 * (ammoLevel + 1));
                Materials.Iron -= (25 * (ammoLevel + 1));
                ammoLevel = 3;
                UpAmmoText.text = "Upgrade Bullet Lv." + (ammoLevel).ToString();
                return;
            }
        }
        else if (ammoLevel == 3)
        {
            if (Materials.Metal >= (25 * (ammoLevel + 1)) && Materials.Iron >= (25 * (ammoLevel + 1)))
            {
                Materials.Metal -= (25 * (ammoLevel + 1));
                Materials.Iron -= (25 * (ammoLevel + 1));
                ammoLevel = 4;
                UpAmmoText.text = "Upgrade Bullet Lv." + (ammoLevel).ToString();
                return;
            }
        }
        else if (ammoLevel == 4)
        {
            if (Materials.Metal >= (25 * (ammoLevel + 1)) && Materials.Iron >= (25 * (ammoLevel + 1)))
            {
                Materials.Metal -= (25 * (ammoLevel + 1));
                Materials.Iron -= (25 * (ammoLevel + 1));
                ammoLevel = 5;
                UpAmmoText.text = "Upgrade Bullet Lv." + (ammoLevel).ToString();
                return;
            }
        }
    }
    void reset()
    {
        SpawnEnemy.spawnLevel = 1;
        PlayerAttack.hasGun = false;
        PlayerAttack.hasPistol = false;
        EnemyAI.reset = true;
        PlayerHealth.playerHealth = 100;
        PlayerMovement.resetPlayerPos = true;
        Materials.Wood = 0;
        Materials.Stone = 0;
        Materials.Metal = 0;
        Materials.Iron = 0;
    }

    void level1()
    {
        playerLevel = 1;
        resetSelect();
        select1.enabled = true;
    }
    void level2()
    {
        playerLevel = 2;
        resetSelect();
        select2.enabled = true;
    }
    void level3()
    {
        playerLevel = 3;
        resetSelect();
        select3.enabled = true;
    }
    void level4()
    {
        playerLevel = 4;
        resetSelect();
        select4.enabled = true;
    }
    void level5()
    {
        playerLevel = 5;
        resetSelect();
        select5.enabled = true;
    }
    void level6()
    {
        playerLevel = 6;
        resetSelect();
        select6.enabled = true;
    }
    void level7()
    {
        playerLevel = 7;
        resetSelect();
        select7.enabled = true;
    }
    void level8()
    {
        playerLevel = 8;
        resetSelect();
        select8.enabled = true;
    }
}
