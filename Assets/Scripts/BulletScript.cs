using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody2D body;

    void Start()
    {
        //add velocity to the bullet at creation 
        body.velocity = transform.up * 5;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        TargetScript target = col.GetComponent<TargetScript>();

        if (target != null)
        {
            target.Death();
        }
    }

}
