using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject enemy;
    public GameObject midEnemy;
    public GameObject largeEnemy;
    public float animTime = 3F;
    public float enemySpeed;
    public float lifetime;
    public int enemyhealth;
    private bool isDead = false;
    private Animator anim;
    private float animTimer = 1.5F;
    public int enemyScore;
    //private bool isHit = false;

    private Vector3? playerDir;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                animTimer -= Time.deltaTime;
                transform.Translate(Vector3.back * enemySpeed * Time.deltaTime);
            }
            if (animTimer <= 0F)
            {
                anim.SetTrigger("Ship Spin");
                animTimer = animTime;
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Find Player"))
            {
                if ((playerDir == null || !playerDir.HasValue) && PlayerController.instance)
                {
                    Vector3 heading = PlayerController.instance.transform.position - transform.position;
                    Vector3 dir = heading / heading.magnitude;
                    dir.y = 0F;
                    playerDir = dir;
                }

                if(playerDir.HasValue)
                {
                    transform.Translate(playerDir.Value * enemySpeed * Time.deltaTime);
                }
            }
        }

        if (midEnemy)
        {

        }

        if (largeEnemy)
        {
            transform.Translate(Vector3.back * enemySpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDead) return;
        if (other.tag == "Shot")
        {
            //isHit = true;

            //if (isHit)
            //{
            //    enemyhealth--;
            //    isHit = false;
            //}

            enemyhealth--;

            if (enemyhealth <= 0)
            {
                Destroy(gameObject);
                isDead = true;
                GameManager.instance.OnEnemyKilled(this);
            }
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
