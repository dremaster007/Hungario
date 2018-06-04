using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{

    public static Animator animator;
    int randPunch;
    bool canAttack = true;
    float delayTime;
    [SerializeField]
    Scrollbar reload;

    [SerializeField]
    GameObject reloadObject;

    [SerializeField]
    Image GunPic;

    [SerializeField]
    Image PistPic;

    [SerializeField]
    GameObject AxePic;

    [SerializeField]
    Text GunAmmo;

    [SerializeField]
    GameObject Gun;

    [SerializeField]
    GameObject Pistol;

    [SerializeField]
    GameObject Axe;

    [SerializeField]
    GameObject Bullet;

    Vector2 BulletPos;
    float shootDelay;
    bool toggle = true;
    bool pistToggle = true;
    bool axeToggle = true;
    float gunAmmo = 0;
    float pistAmmo = 0;
    int clip = 0;
    int pistClip = 0;
    int clipCount = 0;
    int pistolClipCount = 0;
    bool reloading = false;
    public static bool updateGunAmmo = false;
    public static bool updatePistolAmmo = false;
    public static bool isShooting = false;
    public static bool hasGun = false;
    public static bool hasPistol = false;
    public static bool hasAxe = false;

    // Use this for initialization
    void Start () {
        reloadObject.SetActive(false);
        animator = GetComponent<Animator>();
        Bullet.SetActive(false);
        GunAmmo.enabled = false;
        hasAxe = true;
    }
	
	// Update is called once per frame
	void Update () {
        Reload();
        GetGun();
        GetPistol();
        GetTool();
        GunSwap();
        PistolSwap();
        ToolSwap();
        Attack();
    }
    void Reload()
    {
        if (reloading)
        {
            if (reload.size < 1)
            {
                reload.size += 0.34f * Time.deltaTime;
            }
            else if (reload.size >= 1)
            {
                if (animator.GetBool("GunHold") == true && gunAmmo > 0)
                {
                    clipCount = 30 - clip;
                    gunAmmo -= clipCount;
                    clip = 30;
                    GunAmmo.text = clip + ":" + gunAmmo;
                    reload.size = 0;
                    reloading = false;
                    reloadObject.SetActive(false);
                }
                if (animator.GetBool("PistolHold") == true && pistAmmo > 0)
                {
                    pistolClipCount = 15 - pistClip;
                    pistAmmo -= pistolClipCount;
                    pistClip = 15;
                    GunAmmo.text = pistClip + ":" + pistAmmo;
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
        if (hasGun)
        {
            GunPic.enabled = true;
            if (updateGunAmmo)
            {
                gunAmmo += 30;
                if (animator.GetBool("GunHold") == true)
                {
                    GunAmmo.text = clip + ":" + gunAmmo;
                }
                else if (animator.GetBool("PistolHold") == true)
                {
                    GunAmmo.text = pistClip + ":" + pistAmmo;
                }
                updateGunAmmo = false;
            }
            if (Input.GetKeyDown(KeyCode.R) && clip < 30 && !reloading && animator.GetBool("GunHold") == true)
            {
                reload.size = 0;
                reloadObject.SetActive(true);
                reloading = true;
            }
        }
    }

    void GetPistol()
    {
        if (hasPistol)
        {
            PistPic.enabled = true;
            if (updatePistolAmmo)
            {
                pistAmmo += 15;
                if (animator.GetBool("GunHold") == true)
                {
                    GunAmmo.text = clip + ":" + gunAmmo;
                }
                else if (animator.GetBool("PistolHold") == true)
                {
                    GunAmmo.text = pistClip + ":" + pistAmmo;
                }
                updatePistolAmmo = false;
            }
            if (Input.GetKeyDown(KeyCode.R) && pistClip < 30 && !reloading && animator.GetBool("PistolHold") == true)
            {
                reload.size = 0;
                reloadObject.SetActive(true);
                reloading = true;
            }
        }
    }

    void GetTool()
    {
        if (hasAxe)
        {
            AxePic.SetActive(true);
        }
    }

    void GunSwap()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && hasGun)
        {
            GunAmmo.text = clip + ":" + gunAmmo;
            if (toggle)
            {
                pistToggle = true;
                Gun.SetActive(true);
                animator.SetBool("PistolHold", false);
                Pistol.SetActive(false);
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
    }

    void PistolSwap()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && hasPistol)
        {
            GunAmmo.text = pistClip + ":" + pistAmmo;
            if (pistToggle)
            {
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
    }

    void ToolSwap()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3) && hasAxe)
        {
            if (axeToggle)
            {
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
            if (animator.GetBool("GunHold") == true && clip > 0)
            {
                clip--;
                GunAmmo.text = clip + ":" + gunAmmo;
                canAttack = false;
                isShooting = true;
                Bullet.SetActive(true);
                BulletPos = Bullet.transform.position;
                GameObject bulletClone = (Instantiate(Bullet, BulletPos, transform.rotation)) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = transform.up * 10;
                Bullet.SetActive(false);
                shootDelay = 0.25f;
                StartCoroutine(ShootDelay());
                return;
            }
            if (animator.GetBool("PistolHold") == true && pistClip > 0)
            {
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
            if (animator.GetBool("AxeHold") == true)
            {
                canAttack = false;
                animator.SetBool("AxeSwing", true);
                delayTime = 0.5f;
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
