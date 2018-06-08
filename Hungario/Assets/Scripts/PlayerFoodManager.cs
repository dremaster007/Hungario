using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoodManager : MonoBehaviour
{

    public GameObject statManager;

	void Awake ()
    {
        statManager.GetComponent<StatManager>().food = 100f;
        statManager.GetComponent<StatManager>().water = 100f;
        statManager.GetComponent<StatManager>().cold = 100f;
        statManager.GetComponent<StatManager>().health = 100f;
        StartCoroutine(StatManagement());
	}

    IEnumerator StatManagement()
    {
        yield return new WaitForSeconds(5f);
        statManager.GetComponent<StatManager>().food -= 3f;
        statManager.GetComponent<StatManager>().water -= 1f;
        statManager.GetComponent<StatManager>().cold -= 5f;
        StartCoroutine(StatManagement());
    }

}