using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsControl : MonoBehaviour {

    public static bool looseHeat = true;
    public static bool gainHeat = false;
    public static bool looseWater = true;
    public static bool gainWater = false;

    public static float Health = 100;
    public static float Heat = 100;
    public static float Water = 100;

    float tickTime = 0;
    [SerializeField]
    float tickInterval = 30;
    bool updateStats = false;

    [SerializeField]
    public Slider health;
    [SerializeField]
    public Slider heat;
    [SerializeField]
    public Slider water;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gainHeat)
        {
            Heat += 1 * Time.deltaTime;
            heat.value = Heat;
        }
        if (gainWater)
        {
            Water += 1 * Time.deltaTime;
            water.value = Water;
        }
        if (tickTime < tickInterval)
        {
            tickTime += 1 * Time.deltaTime;
        }else if (tickTime >= tickInterval)
        {
            tickTime = 0;
            updateStats = true;
        }
        if (updateStats)
        {
            if (looseHeat)
            {
                Heat -= Random.Range(3, 5);
                heat.value = Heat;
            }
            if (looseWater)
            {
                Water -= Random.Range(3, 5);
                water.value = Water;
            }
            if (Health > 100)
            {
                Health = 100;
            }
            if (Heat > 100)
            {
                Heat = 100;
            }
            if (Water > 100)
            {
                Water = 100;
            }
            updateStats = false;
        }
	}
}
