﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody2D body;
    private int count = 0;
    public APScript APScript;

    void Start()
    {
        //add velocity to the bullet at creation 
        body.velocity = transform.up * 5;
        APScript = GameObject.FindGameObjectWithTag("APHandler").GetComponent<APScript>();
    }

    void Update()
    {
        if(count < 500)
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
        TargetScript target = col.GetComponent<TargetScript>();

        if (target != null)
        {
            target.Death();
            APScript.UpScore();
        }
    }

}
