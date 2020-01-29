using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : Enemy
{
    public GameObject bullet;

    public GameObject spawn;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(PrepareShoot());
    }

    protected override void Update()
    {
        if (player != null)
        {
            base.Update();
        }

        rb.velocity = Vector3.zero;
    }


    IEnumerator PrepareShoot()
    {
        yield return new WaitForSeconds(0.5f);

        while (!gameManager.readyToRestart)
        {
            Shoot();
            yield return new WaitForSeconds(1f);
        }
    }

    protected virtual void Shoot()
    {
        Instantiate(bullet, spawn.transform.position, transform.rotation);
    }
}
