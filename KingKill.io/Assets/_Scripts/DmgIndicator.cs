using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DmgIndicator : MonoBehaviour {

    [SerializeField]
    Image Dmg;
    public static bool damage = false;

    private void Start()
    {
        Dmg.enabled = false;
    }

    // Update is called once per frame
    void Update () {
        if (damage)
        {
            Dmg.enabled = true;
            StartCoroutine(ResetDmg());
        }
	}

    IEnumerator ResetDmg()
    {
        yield return new WaitForSeconds(0.3f);
        Dmg.enabled = false;
        damage = false;
    }
}
