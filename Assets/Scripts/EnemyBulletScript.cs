using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public Rigidbody2D body;
    private int count = 0;

    void Start()
    {
        //add velocity to the bullet at creation 
        body.velocity = transform.up * 2.5f;
    }

    void Update()
    {
        if (count < 500)
        {
            count++;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        TankScript target = col.GetComponent<TankScript>();

        if (target != null)
        {
            target.Death();
        }
    }

}
