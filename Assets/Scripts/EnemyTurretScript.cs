using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretScript : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bullet;
    public EnemyAPScript APScript;

    // Update is called once per frame
    void Update()
    {
        int count = 0;

        if(count < 288)
        {
            count++;
        }
        else
        {
            //Aims turret based on Random Int
            RotateTurret();
            count = 0;
        }

        if (APScript.ap > 0)
        {
            //If enough AP
            if (APScript.canAction)
            {
                //Fire Bullet
                Fire();
                //Reduce AP by 1
                APScript.ap--;
            }
        }
    }

    private void RotateTurret()
    {
        int choice = Random.Range(0, 3);


        if (choice == 0)
        {
            //Point turret Up
            Quaternion rot = Quaternion.Euler(0f, 0f, 0f);
            transform.rotation = rot;
        }

        else if (choice == 1)
        {
            //Point turret Left
            Quaternion rot = Quaternion.Euler(0f, 0f, 90f);
            transform.rotation = rot;
        }

        else if (choice == 2)
        {
            //Point turret Down
            Quaternion rot = Quaternion.Euler(0f, 0f, 180f);
            transform.rotation = rot;
        }

        else if (choice == 3)
        {
            //Point turret Right
            Quaternion rot = Quaternion.Euler(0f, 0f, 270f);
            transform.rotation = rot;
        }
    }

    private void Fire()
    {
        //Creates a bullet prefab at the current position and rotation of the firepoint
        Instantiate(bullet, firepoint.position, firepoint.rotation);
    }
}
