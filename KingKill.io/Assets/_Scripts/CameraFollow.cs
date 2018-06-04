using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    Vector3 playerPosition = new Vector3();

    public GameObject player;

    void Update()
    {
        playerPosition = player.transform.position;
        playerPosition.z -= 1;
        transform.position = playerPosition;
    }
}
