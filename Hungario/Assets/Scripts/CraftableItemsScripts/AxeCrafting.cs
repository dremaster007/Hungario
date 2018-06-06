 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeCrafting : MonoBehaviour {

    public int woodNeeded = 10;
    public int stoneNeeded = 5;

    public GameObject axe;
	
    public void CraftAxe(int woodNeededAmountInPlayer, int stoneNeededAmountInPlayer)
    {
        if (woodNeeded == woodNeededAmountInPlayer && stoneNeeded == stoneNeededAmountInPlayer)
        {
            gameObject.SetActive(true);
        }
    }

}
