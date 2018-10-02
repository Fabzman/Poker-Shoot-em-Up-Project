using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float Speed;
    private Rigidbody rigidBody;
    private Vector3 movement;
    private Vector3 moveSpeed;

    public bool isShooting;
    public float bulletSpeed;
    public float nextShot;
    public float shotTimer;
    public Shot shot;
    public Transform barrelPoint;

    // Use this for initialization
    void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveSpeed = movement * Speed;

        if (Input.GetMouseButtonDown(0))
        {
            isShooting = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isShooting = false;
        }

        if (isShooting)
        {
            shotTimer -= Time.deltaTime;

            if (shotTimer <= 0)
            {
                shotTimer = nextShot;
                Shot newBullet = Instantiate(shot, barrelPoint.position, barrelPoint.rotation) as Shot;
                newBullet.bulletSpeed = bulletSpeed;
            }
        }

        else
        {
            shotTimer = 0;
        }
    }

    void FixedUpdate()
    {
        rigidBody.velocity = moveSpeed;
    }
}
