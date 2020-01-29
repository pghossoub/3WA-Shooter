using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : Enemy
{
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        if (player != null)
        {
            base.Update();
        }

        rb.velocity = Vector3.zero;
    }
}
