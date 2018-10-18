using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject enemy;
    public GameObject midEnemy;
    public GameObject largeEnemy;
    public float enemySpeed;
    public float lifetime;
    public int enemyhealth;
    private bool isDead = false;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemy)
        {
            transform.Translate(Vector3.back * enemySpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDead) return;
        if (other.tag == "Shot")
        {
            GameManager.instance.OnEnemyKilled(this);
            Destroy(gameObject);
            isDead = true;
        }

        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }  
}
