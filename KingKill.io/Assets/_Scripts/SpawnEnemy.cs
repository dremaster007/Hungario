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
    Text Score;

    public float WaveDelay = 30;
    int randSpawn;
    bool SpawnWave = false;
    int spawnCount = 0;
    int spawnLevel = 1;
    public static int EnemyCount;
    bool delayNextWave = true;

	// Use this for initialization
	void Start () {
        StartCoroutine(WaitForWave());
	}
	
	// Update is called once per frame
	void Update () {
        if (delayNextWave)
        {
            if (EnemyCount == 0){
                Debug.Log("Incoming Wave in " + WaveDelay + " seconds..."); 
                delayNextWave = false;
                spawnCount = 0;
                StartCoroutine(WaitForWave());
            }
        }
		if (SpawnWave && !delayNextWave)
        {
            if (spawnCount < (4 * spawnLevel))
            {
                randSpawn = Random.Range(1, 5);
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
                spawnCount += 1;
            }
            else
            {
                Debug.Log("Delaying Wave...");
                delayNextWave = true;
                SpawnWave = false;
                spawnCount = 0;
                spawnLevel += 1;
                Score.text = "Wave " + spawnLevel;
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
