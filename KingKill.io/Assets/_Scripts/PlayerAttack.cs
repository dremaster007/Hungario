using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {

    public Animator animator;
    int randPunch;
    bool canAttack = true;
    float delayTime;
    [SerializeField]
    Image GunPic;
    [SerializeField]
    GameObject Gun;
    [SerializeField]
    GameObject Bullet;
    Vector2 BulletPos;
    bool toggle = true;
    public static bool isShooting = false;
    public static bool hasGun = false;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        Bullet.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (hasGun)
        {
            GunPic.GetComponent<Image>().enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && hasGun)
        {
            if (toggle)
            {
                Gun.SetActive(true);
                animator.SetBool("GunHold", true);
                toggle = false;
            }
            else if (!toggle)
            {
                Gun.SetActive(false);
                animator.SetBool("GunHold", false);
                toggle = true;
            }
        }
        if (Input.GetButtonDown("Fire1") && canAttack)
        {
            if (animator.GetBool("GunHold"))
            {
                canAttack = false;
                isShooting = true;
                Bullet.SetActive(true);
                BulletPos = Bullet.transform.position;
                GameObject bulletClone = (Instantiate(Bullet, BulletPos, transform.rotation)) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = transform.up * 10;
                Bullet.SetActive(false);
                StartCoroutine(ShootDelay());
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
    }
    IEnumerator PunchDelay()
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("PunchR", false);
        animator.SetBool("PunchL", false);
    }
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(0.4f);
        canAttack = true;
        isShooting = false;
    }
}
