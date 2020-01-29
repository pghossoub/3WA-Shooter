using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : EnemyRange
{
    public GameObject[] spawns;

    private Vector3 randomDirection = Vector3.right;
    private bool randomBehavior = true;

    protected override void Start()
    {
        base.Start();

        StartCoroutine(chooseBehavior());
        StartCoroutine(chooseRandomDirection());
    }
    protected override void Update()
    {
        if (player != null)
        {
            base.Update();
        }

        rb.velocity = Vector3.zero;
    }

    protected override void Move()
    {
        if (!randomBehavior) {
            //normal move
            /*Vector3 playerPosition = player.transform.position;
            Vector3 enemyPosition = transform.position;
            Vector3 direction = (playerPosition - enemyPosition);
            transform.Translate(direction * Time.deltaTime * speed);
            */

            base.Move();
        }

        else
        //Random move
        transform.Translate(randomDirection * Time.deltaTime * speed);
    }

    IEnumerator chooseBehavior()
    {
        while (true)
        {
            if (randomBehavior)
                randomBehavior = false;
            else
                randomBehavior = true;

            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator chooseRandomDirection()
    {
        while (true)
        {
            int randomNum = Random.Range(0, 4);
            switch (randomNum)
            {
                case 0:
                    randomDirection = Vector3.right;
                    break;
                case 1:
                    randomDirection = Vector3.left;
                    break;
                case 2:
                    randomDirection = Vector3.forward;
                    break;
                case 3:
                    randomDirection = Vector3.back;
                    break;
            }

            yield return new WaitForSeconds(3.0f);
        }
    }

    protected override void Shoot()
    {
        foreach(GameObject spawn in spawns)
        {
            Instantiate(bullet, spawn.transform.position, spawn.transform.rotation);
        }
    }
}
