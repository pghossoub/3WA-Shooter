using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 800f;

    public GameObject bullet;
    public GameObject spawn;

    private AudioSource pewpewSound;
    private Rigidbody rb;
    private Vector3 direction;

    void Awake()
    {
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pewpewSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Vector3 position = rb.position;
        direction = Vector3.zero;

        /*
        if (Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0)
        {

            //AddForce
            //MovePosition
            //deltaTime adapte au fps
            //newPosition = position + velocity;
            //transform.Translate(Vector3.right * Time.deltaTime * m_speed);
            //velocity = direction * Time.deltaTime * m_speed;
            //rb.velocity += velocity;

            direction += Vector3.right;
            
        }

        if (Input.GetKey(KeyCode.Q) || Input.GetAxis("Horizontal") < 0)
        {
            //velocity = direction * Time.deltaTime * m_speed;
            //rb.velocity += velocity;

            direction += Vector3.left;
            

        }

        if (Input.GetKey(KeyCode.Z) || Input.GetAxis("Vertical") > 0)
        {
            //velocity = direction * Time.deltaTime * m_speed;
            //rb.velocity += velocity;

            direction += Vector3.forward;

        }

        if (Input.GetKey(KeyCode.S) || Input.GetAxis("Vertical") < 0)
        {
            //velocity = direction * Time.deltaTime * m_speed;
            //rb.velocity += velocity;

            direction += Vector3.back;
            //-----------------------------------------------------------------------------------------
            //en utilisant le float, on peut se déplacer plus ou moins vite Vector3 * Input.GetAxis()
            //-----------------------------------------------------------------------------------------
        }
        /*
        if (Input.GetKey(KeyCode.K) || Input.GetAxis("4thAxis") < 0)
        {
            Quaternion toRotate = Quaternion.LookRotation(Vector3.left, Vector3.up);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate);
            transform.rotation = toRotate;
        }

        if (Input.GetKey(KeyCode.M) || Input.GetAxis("4thAxis") > 0)
        {
            Quaternion toRotate = Quaternion.LookRotation(Vector3.right, Vector3.up);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate);
            transform.rotation = toRotate;
        }

        if (Input.GetKey(KeyCode.O) || Input.GetAxis("5thAxis") > 0)
        {
            Quaternion toRotate = Quaternion.LookRotation(Vector3.forward, Vector3.up);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate);
            transform.rotation = toRotate;
        }

        if (Input.GetKey(KeyCode.L) || Input.GetAxis("5thAxis") < 0)
        {
            Quaternion toRotate = Quaternion.LookRotation(Vector3.back, Vector3.up);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate);
            transform.rotation = toRotate;
        }
        */

        //rb.velocity = direction.normalized * speed * Time.deltaTime;

        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        rb.velocity = direction * speed * Time.deltaTime;

        Vector3 lookAt = new Vector3(Input.GetAxis("4thAxis"), 0, Input.GetAxis("5thAxis"));

        if (lookAt != Vector3.zero && lookAt.sqrMagnitude > 0.2)
        {
            transform.rotation = Quaternion.LookRotation(lookAt, Vector3.up);
        }

        if (Input.GetButtonDown("Fire1")){
            pewpewSound.Play();
            Instantiate(bullet, spawn.transform.position, transform.rotation);
        }
    }

    
}
