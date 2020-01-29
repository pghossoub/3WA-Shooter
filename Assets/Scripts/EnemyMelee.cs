using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public float speed = 10f;

    //public GameObject player;

    private GameObject player;
    private AudioSource explodeSound;
    private Rigidbody rb;
    private GameController gameController;

    private void Start()
    {
        explodeSound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

    }
    void Update()
    {
        if (player != null) { 
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

        rb.velocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            explodeSound.Play();
            //wait for the sound to play
            Destroy(gameObject, 0.05f);
        }

        if(collision.gameObject.tag == "Player")
        {
            explodeSound.Play();
            Destroy(player);
            gameController.readyToRestart = true;
            gameController.GameOver();
        }
    }
}
