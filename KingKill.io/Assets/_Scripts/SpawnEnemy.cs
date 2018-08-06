using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour {

    [SerializeField]
    GameObject EnemyPrefab;

    [SerializeField]
    GameObject spawn1;

    [SerializeField]
    GameObject spawn2;

    [SerializeField]
    GameObject spawn3;

    [SerializeField]
    GameObject spawn4;

    [SerializeField]
    GameObject spawn5;

    [SerializeField]
    GameObject spawn6;

    [SerializeField]
    GameObject spawn7;

    [SerializeField]
    GameObject spawn8;

    [SerializeField]
    Text Score;

    [SerializeField]
    Text EnemyAmount;

    public float WaveDelay = 30;
    int randSpawn;
    bool SpawnWave = false;
    int spawnCount = 0;
    public static int spawnLevel = 1;
    public static int EnemyCount;
    public static bool delayNextWave = true;

	// Use this for initialization
	void Start () {
        StartCoroutine(WaitForWave());
        Score.text = "Wave " + (spawnLevel - 1);
    }
	
	// Update is called once per frame
	void Update () {
        EnemyAmount.text = "Enemies: " + EnemyCount;
        if (delayNextWave)
        {
            if (EnemyCount == 0){
                delayNextWave = false;
                spawnCount = 0;
                StartCoroutine(WaitForWave());
            }
        }
		else if (SpawnWave && !delayNextWave)
        {
            if (spawnCount < (10 * spawnLevel))
            {
                randSpawn = Craft.playerLevel;
                if (randSpawn == 1)
                {
                    EnemyPrefab.SetActive(true);
                    GameObject EnemyClone = Instantiate(EnemyPrefab);
                    EnemyClone.transform.position = spawn1.transform.position;
                    EnemyCount++;
                    EnemyPrefab.SetActive(false);
                }else if (randSpawn == 2)
                {
                    EnemyPrefab.SetActive(true);
                    GameObject EnemyClone = Instantiate(EnemyPrefab);
                    EnemyClone.transform.position = spawn2.transform.position;
                    EnemyCount++;
                    EnemyPrefab.SetActive(false);
                }
                else if (randSpawn == 3)
                {
                    EnemyPrefab.SetActive(true);
                    GameObject EnemyClone = Instantiate(EnemyPrefab);
                    EnemyClone.transform.position = spawn3.transform.position;
                    EnemyCount++;
                    EnemyPrefab.SetActive(false);
                }
                else if (randSpawn == 4)
                {
                    EnemyPrefab.SetActive(true);
                    GameObject EnemyClone = Instantiate(EnemyPrefab);
                    EnemyClone.transform.position = spawn4.transform.position;
                    EnemyCount++;
                    EnemyPrefab.SetActive(false);
                }
                else if (randSpawn == 5)
                {
                    EnemyPrefab.SetActive(true);
                    GameObject EnemyClone = Instantiate(EnemyPrefab);
                    EnemyClone.transform.position = spawn5.transform.position;
                    EnemyCount++;
                    EnemyPrefab.SetActive(false);
                }
                else if (randSpawn == 6)
                {
                    EnemyPrefab.SetActive(true);
                    GameObject EnemyClone = Instantiate(EnemyPrefab);
                    EnemyClone.transform.position = spawn6.transform.position;
                    EnemyCount++;
                    EnemyPrefab.SetActive(false);
                }
                else if (randSpawn == 7)
                {
                    EnemyPrefab.SetActive(true);
                    GameObject EnemyClone = Instantiate(EnemyPrefab);
                    EnemyClone.transform.position = spawn7.transform.position;
                    EnemyCount++;
                    EnemyPrefab.SetActive(false);
                }
                else if (randSpawn == 8)
                {
                    EnemyPrefab.SetActive(true);
                    GameObject EnemyClone = Instantiate(EnemyPrefab);
                    EnemyClone.transform.position = spawn8.transform.position;
                    EnemyCount++;
                    EnemyPrefab.SetActive(false);
                }
                spawnCount += 1;
            }
            else
            {
                delayNextWave = true;
                SpawnWave = false;
                spawnCount = 0;
                if (spawnLevel == 1)
                {
                    spawnLevel++;
                }
                else
                {
                    spawnLevel += 1;
                }
                Score.text = "Wave " + (spawnLevel - 1);
            }
        }
	}
    IEnumerator WaitForWave()
    {
        if (WaveDelay > 5)
        {
            WaveDelay -= 1;
        }
        yield return new WaitForSeconds(WaveDelay);
        SpawnWave = true;
    }
}
