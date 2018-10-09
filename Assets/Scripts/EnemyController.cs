using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject powerUp;
    public GameObject enemy;
    public float enemySpeed;
    public float lifetime;
    public int powerupCount;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * enemySpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Shot")
        {
            powerupCount += 1;
            Destroy(gameObject);
        }

        //if (powerupCount <= 0)
        //{
        //    Instantiate(powerUp, transform.position, transform.rotation);
        //}

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
