using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float fireRate;

    public GameObject bullet;
    public GameObject spawn;
    public GameObject explosion;

    private AudioSource explodeSound;
    private Rigidbody rb;
    private GameManager gameManager;

    private float nextFire;

    void Awake()
    {
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        explodeSound = GetComponent<AudioSource>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        nextFire = 0f;
    }

    void Update()
    {
     
        Vector3 direction = Vector3.zero;

        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        rb.velocity = direction * speed * Time.deltaTime;

        Vector3 lookAt = new Vector3(Input.GetAxis("4thAxis"), 0, Input.GetAxis("5thAxis"));

        if (lookAt != Vector3.zero && lookAt.sqrMagnitude > 0.2)
        {
            transform.rotation = Quaternion.LookRotation(lookAt, Vector3.up);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, spawn.transform.position, transform.rotation);
        }

        if (Input.GetAxis("Fire1") > 0 && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, spawn.transform.position, transform.rotation);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            explodeSound.Play();
            Instantiate(explosion, transform.position, transform.rotation);
            //wait for the sound to play
            gameManager.GameOver();
            gameManager.readyToRestart = true;
            Destroy(gameObject, 0.05f);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            explodeSound.Play();
            Instantiate(explosion, transform.position, transform.rotation);
            gameManager.readyToRestart = true;
            gameManager.GameOver();
            Destroy(gameObject, 0.05f);
        }
    }
}
