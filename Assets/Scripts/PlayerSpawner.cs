using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

    public Transform player;
    public GameObject playerTemplate;
    public float reviveTimer = 3f;


	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (!player)
        {
            reviveTimer -= Time.deltaTime;

            if (reviveTimer <= 0)
            {
                player = Instantiate(playerTemplate, transform.position, transform.rotation).transform;
                reviveTimer = 3f;
            }
        }
	}
}
