using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScreenEdge
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    public float Speed;
    private Rigidbody rigidBody;
    private Vector3 movement;
    private Vector3 moveSpeed;

    public bool isDead = false;
    public bool isShooting;
    public bool singleShot;
    public bool twinShot;
    public bool tripleShot;
    public bool finalShot;
    public bool spreadShot;
    public int powerLevel;
    public float bulletSpeed;
    public float nextShot;
    public float shotTimer;
    public Shot shot;
    public Transform barrelPoint;
    public Transform barrelPoint2;
    public Transform barrelPoint3;
    public Transform barrelPoint4;

    public ScreenEdge boundary;

    // Use this for initialization
    void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        singleShot = true;
        twinShot = false;
        tripleShot = false;
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
                Transform barrel = barrelPoint;

                if (powerLevel == 1)
                {
                    barrel = barrelPoint2;
                }

                if (powerLevel == 2)
                {
                    barrel = barrelPoint3;
                }

                if (powerLevel == 3)
                {
                    barrel = barrelPoint4;
                }

                foreach (Transform t in barrel)
                {
                    Shot bullet = Instantiate(shot, t.position, t.rotation);
                    bullet.bulletSpeed = bulletSpeed;
                }

                shotTimer = nextShot;
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

        rigidBody.position = new Vector3
        (
            Mathf.Clamp(rigidBody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigidBody.position.z, boundary.zMin, boundary.zMax)
        );

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
            isDead = true;
        }

        if (other.tag == "Powerup")
        {
            if(powerLevel >= 3)
            {
                return;
            }

            else
            {
                powerLevel++;
            }
        }
    }
}
