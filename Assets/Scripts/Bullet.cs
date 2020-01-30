using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 35f;

    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        /*if(!collision.gameObject.CompareTag("PlayerBullet") && 
            !collision.gameObject.CompareTag("EnemyBullet"))*/
        Destroy(gameObject);
    }
}
