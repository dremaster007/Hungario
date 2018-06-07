using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoodManager : MonoBehaviour {

    public GameObject StatsManagement;

	void Awake () {
        StatsManagement.GetComponent<StatManager>().food = 100f;
        StartCoroutine(FoodManagement());
	}

	void Update () {
		
	}

    IEnumerator FoodManagement()
    {
        yield return new WaitForSeconds(10f);
        StatsManagement.GetComponent<StatManager>().food -= 10f;
        StartCoroutine(FoodManagement());
    }

}
