using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaterManager : MonoBehaviour
{

    public GameObject statManager;

    void Awake()
    {
        statManager.GetComponent<StatManager>().water = 100f;
        StartCoroutine(WaterManagement());
    }

    IEnumerator WaterManagement()
    {
        yield return new WaitForSeconds(10f);
        statManager.GetComponent<StatManager>().water -= 2f;
        StartCoroutine(WaterManagement());
    }

}
