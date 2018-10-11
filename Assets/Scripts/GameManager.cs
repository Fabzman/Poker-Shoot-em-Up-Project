using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public int powerupCount;
    public GameObject powerUp;
    private int killedEnemies;

    private void Awake()
    {
        instance = this;
    }

    public void OnEnemyKilled(EnemyController enemy)
    {
        killedEnemies++;

        if(killedEnemies >= powerupCount)
        {
            killedEnemies = 0;
            Instantiate(powerUp, enemy.transform.position, enemy.transform.rotation);
        }
    }

}
