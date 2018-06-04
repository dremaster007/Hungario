using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    [SerializeField]
    GameObject target;
    float angle;
    bool tickDamage = false;
    bool tickSelf = false;
    bool tickDelay = false;
    public float speed;
    public float Enemyhealth = 1;
	
	// Update is called once per frame
	void Update () {
        if (Enemyhealth <= 0)
        {
            SpawnEnemy.EnemyCount--;
            Destroy(gameObject);
        }
        Vector2 direction = target.transform.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target.transform.position) > 1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        if (tickDamage && !tickDelay)
        {
            tickDelay = true;
            PlayerHealth.playerHealth -= 10;
            StartCoroutine(DamageDelay());
        }
        if (tickSelf && !tickDelay)
        {
            tickDelay = true;
            Enemyhealth -= 0.1f;
            StartCoroutine(DamageDelay());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            tickDamage = true;
        }
        else if (collision.gameObject.name == "thornBush")
        {
            tickSelf = true;
        }
        else if (collision.gameObject.name == "Bullet(Clone)")
        {
            Enemyhealth -= 0.5f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            tickDamage = false;
        }
        else if (collision.gameObject.name == "thornBush")
        {
            tickSelf = false;
        }
    }
    IEnumerator DamageDelay()
    {
        yield return new WaitForSeconds(0.8f);
        tickDelay = false;
        tickSelf = false;
    }
}
