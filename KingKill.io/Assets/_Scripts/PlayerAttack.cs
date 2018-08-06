using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    int randPunch;
    public static bool canAttack = true;
    float delayTime;
    [SerializeField]
    Scrollbar reload;

    [SerializeField]
    Text Reloading;

    [SerializeField]
    GameObject reloadObject;

    [SerializeField]
    Image GunPic;

    [SerializeField]
    Image PistPic;

    [SerializeField]
    Image SGPic;

    [SerializeField]
    GameObject AxePic;

    [SerializeField]
    GameObject PickPic;

    [SerializeField]
    Text GunAmmo;

    [SerializeField]
    GameObject Gun;

    [SerializeField]
    GameObject Pistol;

    [SerializeField]
    GameObject SG;

    [SerializeField]
    GameObject Axe;

    [SerializeField]
    GameObject Pick;

    [SerializeField]
    GameObject Bullet;

    Vector2 BulletPos;
    float shootDelay;
    bool toggle = true;
    bool pistToggle = true;
    bool SGToggle = true;
    bool axeToggle = true;
    bool pickToggle = true;
    public static float gunAmmo = 0;
    public static float pistAmmo = 0;
    public static int clip = 0;
    public static int pistClip = 0;
    public static int SGClip = 0;
    int clipCount = 0;
    int pistolClipCount = 0;
    int SGClipCount = 0;
    bool reloading = false;
    public static bool updateGunAmmo = false;
    public static bool updatePistolAmmo = false;
    public static bool updateSGAmmo = false;
    public static bool isShooting = false;
    public static bool hasGun = false;
    public static bool hasPistol = false;
    public static bool hasSG = false;
    public static bool hasAxe = false;
    public static bool hasPick = false;

    // Use this for initialization
    void Start () {
        reloadObject.SetActive(false);
        Reloading.enabled = false;
        animator = GetComponent<Animator>();
        Bullet.SetActive(false);
        GunAmmo.enabled = false;
        hasAxe = true;
        hasPick = true;
    }
	
	// Update is called once per frame
	void Update () {
        AmmoText();
        Reload();
        GetGun();
        GetTool();
        GunSwap();
        ToolSwap();
        Attack();
    }
    void AmmoText()
    {
        if (Craft.weaponLevel == 1)
        {
            GunAmmo.text = pistClip + ":" + pistAmmo;
        }
        else if (Craft.weaponLevel == 2)
        {
            GunAmmo.text = clip + ":" + gunAmmo;
        }
        else if (Craft.weaponLevel == 3)
        {
            GunAmmo.text = SGClip + ":" + gunAmmo;
        }
    }

    void Reload()
    {
        if (reloading)
        {
            if (reload.size < 1)
            {
                Reloading.enabled = true;
                reload.size += 0.34f * Time.deltaTime;
            }
            else if (reload.size >= 1)
            {
                Reloading.enabled = false;
                if (animator.GetBool("GunHold") == true && gunAmmo > 0)
                {
                    clipCount = 30 - clip;
                    if (gunAmmo < clipCount)
                    {
                        clip = Mathf.RoundToInt(gunAmmo);
                        gunAmmo = 0;
                    }
                    else
                    {
                        gunAmmo -= clipCount;
                    }
                    clip = 30;
                    GunAmmo.text = clip + ":" + gunAmmo;
                    reload.size = 0;
                    reloading = false;
                    reloadObject.SetActive(false);
                }
                if (animator.GetBool("PistolHold") == true && pistAmmo > 0)
                {
                    pistolClipCount = 15 - pistClip;
                    if (gunAmmo < clipCount)
                    {
                        pistClip = Mathf.RoundToInt(pistAmmo);
                        pistAmmo = 0;
                    }
                    else
                    {
                        pistAmmo -= pistolClipCount;
                    }
                    pistClip = 15;
                    GunAmmo.text = pistClip + ":" + pistAmmo;
                    reload.size = 0;
                    reloading = false;
                    reloadObject.SetActive(false);
                }
                if (animator.GetBool("SGHold") == true && gunAmmo > 0)
                {
                    SGClipCount = 7 - clip;
                    if (gunAmmo < SGClipCount)
                    {
                        SGClip = Mathf.RoundToInt(gunAmmo);
                        gunAmmo = 0;
                    }
                    else
                    {
                        gunAmmo -= SGClipCount;
                    }
                    SGClip = 7;
                    GunAmmo.text = SGClip + ":" + gunAmmo;
                    reload.size = 0;
                    reloading = false;
                    reloadObject.SetActive(false);
                }
                reload.size = 0;
                reloading = false;
                reloadObject.SetActive(false);
            }
        }
    }
    void GetGun()
    {
        if (!hasGun && !hasPistol && !hasSG)
        {
            Gun.SetActive(false);
            GunPic.enabled = false;
            animator.SetBool("GunHold", false);
            GunAmmo.enabled = false;
            toggle = true;
            Pistol.SetActive(false);
            PistPic.enabled = false;
            animator.SetBool("PistolHold", false);
            GunAmmo.enabled = false;
            pistToggle = true;
            SG.SetActive(false);
            SGPic.enabled = false;
            animator.SetBool("SGHold", false);
            GunAmmo.enabled = false;
            SGToggle = true;
        }
        if (hasGun || hasPistol || hasSG)
        {
            if (Craft.weaponLevel == 1)
            {
                PistPic.enabled = true;
                if (updatePistolAmmo)
                {
                    pistAmmo += 15;
                    GunAmmo.text = pistClip + ":" + pistAmmo;
                    updatePistolAmmo = false;
                }
                if ((Input.GetKeyDown(KeyCode.R) && pistClip < 15 && pistAmmo > 0 && !reloading && animator.GetBool("PistolHold") == true))
                {
                    reload.size = 0;
                    reloadObject.SetActive(true);
                    reloading = true;
                }
            }
            else if (Craft.weaponLevel == 2)
            {
                PistPic.enabled = false;
                GunPic.enabled = true;
                if (updateGunAmmo)
                {
                    gunAmmo += 30;
                    GunAmmo.text = clip + ":" + gunAmmo;
                    updateGunAmmo = false;
                }
                if ((Input.GetKeyDown(KeyCode.R) && clip < 30 && gunAmmo > 0 && !reloading && animator.GetBool("GunHold") == true))
                {
                    reload.size = 0;
                    reloadObject.SetActive(true);
                    reloading = true;
                }
            }
            else if (Craft.weaponLevel == 3)
            {
                GunPic.enabled = false;
                SGPic.enabled = true;
                if (updateSGAmmo)
                {
                    gunAmmo += 15;
                    GunAmmo.text = SGClip + ":" + gunAmmo;
                    updateSGAmmo = false;
                }
                if ((Input.GetKeyDown(KeyCode.R) && SGClip < 7 && gunAmmo > 0 && !reloading && animator.GetBool("SGHold") == true))
                {
                    reload.size = 0;
                    reloadObject.SetActive(true);
                    reloading = true;
                }
            }
        }
    }

    void GetTool()
    {
        if (hasAxe)
        {
            AxePic.SetActive(true);
        }
        if (hasPick)
        {
            PickPic.SetActive(true);
        }
    }

    void GunSwap()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && (hasGun || hasPistol || hasSG))
        {
            if (Craft.weaponLevel == 1)
            {
                GunAmmo.text = pistClip + ":" + pistAmmo;
                if (pistToggle)
                {
                    axeToggle = true;
                    Axe.SetActive(false);
                    animator.SetBool("AxeHold", false);
                    pickToggle = true;
                    Pick.SetActive(false);
                    animator.SetBool("PickHold", false);
                    toggle = true;
                    Pistol.SetActive(true);
                    animator.SetBool("GunHold", false);
                    Gun.SetActive(false);
                    animator.SetBool("PistolHold", true);
                    GunAmmo.enabled = true;
                    pistToggle = false;
                }
                else if (!pistToggle)
                {
                    Pistol.SetActive(false);
                    animator.SetBool("PistolHold", false);
                    GunAmmo.enabled = false;
                    pistToggle = true;
                }
            }
            else if (Craft.weaponLevel == 2)
            {
                GunAmmo.text = clip + ":" + gunAmmo;
                if (toggle)
                {
                    axeToggle = true;
                    Axe.SetActive(false);
                    animator.SetBool("AxeHold", false);
                    pickToggle = true;
                    Pick.SetActive(false);
                    animator.SetBool("PickHold", false);
                    pistToggle = true;
                    Gun.SetActive(true);
                    animator.SetBool("PistolHold", false);
                    Pistol.SetActive(false);
                    PistPic.enabled = false;
                    animator.SetBool("GunHold", true);
                    GunAmmo.enabled = true;
                    toggle = false;
                }
                else if (!toggle)
                {
                    Gun.SetActive(false);
                    animator.SetBool("GunHold", false);
                    GunAmmo.enabled = false;
                    toggle = true;
                }
            }
            else if (Craft.weaponLevel == 3)
            {
                GunAmmo.text = SGClip + ":" + gunAmmo;
                if (SGToggle)
                {
                    axeToggle = true;
                    Axe.SetActive(false);
                    animator.SetBool("AxeHold", false);
                    pickToggle = true;
                    Pick.SetActive(false);
                    animator.SetBool("PickHold", false);
                    pistToggle = true;
                    animator.SetBool("PistolHold", false);
                    Pistol.SetActive(false);
                    PistPic.enabled = false;
                    SG.SetActive(true);
                    animator.SetBool("SGHold", true);
                    GunAmmo.enabled = true;
                    SGToggle = false;
                }
                else if (!SGToggle)
                {
                    SG.SetActive(false);
                    animator.SetBool("SGHold", false);
                    GunAmmo.enabled = false;
                    SGToggle = true;
                }
            }
        }
    }

    void ToolSwap()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && hasPick)
        {
            reload.size = 0;
            reloadObject.SetActive(false);
            reloading = false;
            if (pickToggle)
            {
                pistToggle = true;
                Pistol.SetActive(false);
                animator.SetBool("PistolHold", false);
                toggle = true;
                Gun.SetActive(false);
                animator.SetBool("GunHold", false);
                axeToggle = true;
                Axe.SetActive(false);
                animator.SetBool("AxeHold", false);
                SGToggle = true;
                SG.SetActive(false);
                animator.SetBool("SGHold", false);
                Pick.SetActive(true);
                animator.SetBool("PickHold", true);
                pickToggle = false;
            }
            else if (!pickToggle)
            {
                Pick.SetActive(false);
                animator.SetBool("PickHold", false);
                pickToggle = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && hasAxe)
        {
            reload.size = 0;
            reloadObject.SetActive(false);
            reloading = false;
            if (axeToggle)
            {
                pistToggle = true;
                Pistol.SetActive(false);
                animator.SetBool("PistolHold", false);
                toggle = true;
                Gun.SetActive(false);
                animator.SetBool("GunHold", false);
                SGToggle = true;
                SG.SetActive(false);
                animator.SetBool("SGHold", false);
                pickToggle = true;
                Pick.SetActive(false);
                animator.SetBool("PickHold", false);
                Axe.SetActive(true);
                animator.SetBool("AxeHold", true);
                axeToggle = false;
            }else if (!axeToggle)
            {
                Axe.SetActive(false);
                animator.SetBool("AxeHold", false);
                axeToggle = true;
            }
        }
    }

    void Attack()
    {
        if (Input.GetButton("Fire1") && canAttack && !reloading)
        {
            if (animator.GetBool("GunHold") == true)
            {
                if (clip <= 0)
                {
                    reload.size = 0;
                    reloadObject.SetActive(true);
                    reloading = true;
                    return;
                }
                clip--;
                GunAmmo.text = clip + ":" + gunAmmo;
                canAttack = false;
                isShooting = true;
                Bullet.SetActive(true);
                BulletPos = Bullet.transform.position;
                GameObject bulletClone = (Instantiate(Bullet, BulletPos, transform.rotation)) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = transform.up * 10;
                Bullet.SetActive(false);
                shootDelay = 0.15f;
                StartCoroutine(ShootDelay());
                return;
            }
            if (animator.GetBool("PistolHold") == true)
            {
                if (pistClip <= 0)
                {
                    reload.size = 0;
                    reloadObject.SetActive(true);
                    reloading = true;
                    return;
                }
                pistClip--;
                GunAmmo.text = pistClip + ":" + pistAmmo;
                canAttack = false;
                isShooting = true;
                Bullet.SetActive(true);
                BulletPos = Bullet.transform.position;
                GameObject bulletClone = (Instantiate(Bullet, BulletPos, transform.rotation)) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = transform.up * 10;
                Bullet.SetActive(false);
                shootDelay = 0.5f;
                StartCoroutine(ShootDelay());
                return;
            }
            if (animator.GetBool("SGHold") == true)
            {
                if (SGClip <= 0)
                {
                    reload.size = 0;
                    reloadObject.SetActive(true);
                    reloading = true;
                    return;
                }
                SGClip--;
                GunAmmo.text = SGClip + ":" + gunAmmo;
                canAttack = false;
                isShooting = true;
                Bullet.SetActive(true);
                BulletPos = Bullet.transform.position;
                GameObject bulletClone = (Instantiate(Bullet, BulletPos, transform.rotation)) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = transform.up * 10;
                Bullet.SetActive(false);
                shootDelay = 0.6f;
                StartCoroutine(ShootDelay());
                return;
            }
            if (animator.GetBool("AxeHold") == true)
            {
                canAttack = false;
                animator.SetBool("AxeSwing", true);
                delayTime = 0.35f;
                StartCoroutine(AttackDelay());
                return;
            }
            if (animator.GetBool("PickHold") == true)
            {
                canAttack = false;
                animator.SetBool("PickSwing", true);
                delayTime = 0.35f;
                StartCoroutine(AttackDelay());
                return;
            }
            canAttack = false;
            delayTime = 0.3f;
            randPunch = Random.Range(1, 3);
            if (randPunch == 1)
            {
                animator.SetBool("PunchL", true);
                animator.SetBool("PunchR", false);
                StartCoroutine(PunchDelay());
            }
            if (randPunch == 2)
            {
                animator.SetBool("PunchR", true);
                animator.SetBool("PunchL", false);
                StartCoroutine(PunchDelay());
            }
            StartCoroutine(AttackDelay());
        }
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(delayTime);
        canAttack = true;
        animator.SetBool("AxeSwing", false);
        animator.SetBool("PickSwing", false);
    }
    IEnumerator AxeDelay()
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("AxeSwing", false);
        yield return new WaitForSeconds(delayTime);
        canAttack = true;
    }
    IEnumerator PunchDelay()
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("PunchR", false);
        animator.SetBool("PunchL", false);
    }
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shootDelay);
        canAttack = true;
        isShooting = false;
    }
}
