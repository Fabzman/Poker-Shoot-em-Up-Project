using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    public float powerupSpeed;
    public float lifetime;
    public EnemyController powerupCount;


    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        //makes the power up move
        transform.Translate(Vector3.back * powerupSpeed * Time.deltaTime);

        //if (powerupCount <= 0)
        //{
        //    Instantiate(powerUp, transform.position, transform.rotation);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
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
