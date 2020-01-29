using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public GameObject explosion;

    private AudioSource explodeSound;
    private bool dead = false;
    protected GameManager gameManager;

    protected GameObject player;
    protected Rigidbody rb;

    protected virtual void Start()
    {
        explodeSound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 enemyPosition = transform.position;
        Vector3 direction = (playerPosition - enemyPosition);
        Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);

        lookRotation.x = 0;
        lookRotation.z = 0;

        //transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 1f);
        //rb.AddForce(transform.rotation * Vector3.forward * speed);
        transform.rotation = lookRotation;

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (!dead)
        {
            if (collision.gameObject.tag == "PlayerBullet")
            {
                dead = true;
                gameManager.addScore();
                explodeSound.Play();
                Instantiate(explosion, transform.position, transform.rotation);
                //wait for the sound to play
                Destroy(gameObject, 0.05f);
            }

            if (collision.gameObject.tag == "EnemyBullet")
            {

                Destroy(collision.gameObject);
            }

            /*
            if (collision.gameObject.tag == "Player")
            {
                explodeSound.Play();
                Destroy(player);
                gameManager.readyToRestart = true;
                gameManager.GameOver();
            }
            */
        }
    }
}
