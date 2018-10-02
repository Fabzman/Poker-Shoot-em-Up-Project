using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    public float bulletSpeed;
    public float lifetime;


    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        //makes the bullet go whoosh
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
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
