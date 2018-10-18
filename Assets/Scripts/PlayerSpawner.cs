using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

    public GameObject player;
    public Transform playerSpawner;
    public PlayerController death;


	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (death)
        {
            Instantiate(player, playerSpawner.position, playerSpawner.rotation);
        }
	}
}
