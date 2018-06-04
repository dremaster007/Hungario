using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAITestPaul : MonoBehaviour {

    [SerializeField]
    GameObject target;
    Vector3 velocity;
    bool chase = false;
    float angle;
    public float speed;
    bool toggle = true;

    private void Update()
    {
        if (chase)
        {
            Vector2 direction = target.transform.position - transform.position;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, target.transform.position) > 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "PlayerTDS")
        {
            if (toggle)
            {
                chase = true;
            }
            else if (!toggle)
            {
                chase = false;
            }
        }
    }
}
