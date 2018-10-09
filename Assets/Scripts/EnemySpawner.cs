using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public float nextSpawn;
    public float spawnTimer;
    public Transform enemySpawner;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        nextSpawn -= 1;

        if (nextSpawn <= 0)
        {
            spawnTimer -= 1;
            nextSpawn = 5;
        }

        if (spawnTimer <= 0)
        {
            Instantiate(enemy, enemySpawner.position, enemySpawner.rotation);
            spawnTimer = 5;
        }
    }
}
