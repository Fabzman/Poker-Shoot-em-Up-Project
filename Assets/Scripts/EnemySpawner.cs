using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    private float nextSpawn;
    public int enemyCount;
    private int currentCount;
    public float spawnWait = 10;
    public float spawnTime = 2.5F;
    public Transform enemySpawner;

    // Use this for initialization
    void Start ()
    {
        nextSpawn = spawnTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (currentCount >= enemyCount)
        {
            currentCount = 0;
            nextSpawn = spawnWait;
        }

        nextSpawn -= Time.deltaTime;

        if (nextSpawn <= 0)
        {
            Instantiate(enemy, enemySpawner.position, enemySpawner.rotation);
            nextSpawn = spawnTime;
            currentCount++;
        }
    }
}
