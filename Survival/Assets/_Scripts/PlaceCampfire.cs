using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCampfire : MonoBehaviour {

    [SerializeField]
    GameObject campPos;
    [SerializeField]
    GameObject CampFirePrefab;
    [SerializeField]
    GameObject CampFireHighlight;
    [SerializeField]
    GameObject CampFireHighlightBad;
    public static bool canPlace = true;
    bool isSelected = false;
    bool toggleSlelect = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (toggleSlelect)
            {
                isSelected = true;
                toggleSlelect = false;
            }
            else if (!toggleSlelect)
            {
                isSelected = false;
                toggleSlelect = true;
            }
        }
        if (isSelected)
        {
            if (Materials.wood > 200 && Materials.stone > 50)
            {
                CampFireHighlight.SetActive(true);
                CampFireHighlightBad.SetActive(false);
            }
            else
            {
                CampFireHighlight.SetActive(false);
                CampFireHighlightBad.SetActive(true);
            }
        }
        if (!isSelected)
        {
            CampFireHighlight.SetActive(false);
            CampFireHighlightBad.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && isSelected && canPlace)
        {
            if (Materials.wood > 200 && Materials.stone > 50)
            {
                Materials.wood -= 200;
                Materials.stone -= 50;
                isSelected = false;
                CampFireHighlight.SetActive(false);
                CampFirePrefab.SetActive(true);
                GameObject campDupe = Instantiate(CampFirePrefab);
                campDupe.transform.rotation = campPos.transform.rotation;
                campDupe.transform.position = new Vector3(campPos.transform.position.x, campPos.transform.position.y, campPos.transform.position.z);
                CampFirePrefab.SetActive(false);
            }
            
        }
	}
}
