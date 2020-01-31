using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float pv = 1;
    public float speed = 10f;
    public float bounceTime = 0.1f;
    public GameObject deathExplosion;
    public GameObject dmgExplosion;

    public FloatVariable score;

    private AudioSource explodeSound;
    private bool isDead = false;
    private float nextDamage;

    protected GameObject player;
    protected Rigidbody rb;

    protected virtual void Start()
    {
        explodeSound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected virtual void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        //calculate rotation: towards Player

        Vector3 playerPosition = player.transform.position;
        Vector3 enemyPosition = transform.position;
        Vector3 direction = (playerPosition - enemyPosition);
        Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);

        lookRotation.x = 0;
        lookRotation.z = 0;

        transform.rotation = lookRotation;

        //Move forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (!isDead)
        {
            if (collision.gameObject.tag == "PlayerBullet" && Time.time > nextDamage)
            {
                nextDamage = Time.time + bounceTime;

                Instantiate(dmgExplosion, collision.gameObject.transform.position, transform.rotation);
                if (pv <= 1)
                { 
                    isDead = true;
                    score.value += 1f;
                    explodeSound.Play();
                    Instantiate(deathExplosion, transform.position, transform.rotation);
                    Destroy(gameObject, 0.05f);
                }
                else
                {
                    pv--;
                }
            }

            if (collision.gameObject.tag == "EnemyBullet")
            {

                Destroy(collision.gameObject);
            }
        }
    }
}
