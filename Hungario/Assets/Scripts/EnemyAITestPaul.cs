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
    //bool toggle = true;

    public CircleCollider2D cc2D;
    public PolygonCollider2D pc2D;

    public void Start()
    {
        cc2D = GetComponent<CircleCollider2D>();
        pc2D = GetComponent<PolygonCollider2D>();
    }

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

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name == "PlayerTDS")
        {
            chase = true;

            cc2D.radius = 4.5f;

            /*if (toggle)
            {
                chase = true;
            }*/

            /*else if (!toggle)
            {
                chase = false;
            }*/
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "PlayerTDS")
        {
            chase = false;
            cc2D.radius = 3.5f;
        }
    }
}
