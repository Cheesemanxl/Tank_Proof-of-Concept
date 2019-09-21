using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    private Transform firepoint;
    public GameObject bullet;
    public APScript APScript;

    // Start is called before the first frame update
    void Start()
    {
        //assign firepoint to the gameobject with the firepoint tag
        firepoint = GameObject.FindGameObjectWithTag("FirePoint").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (APScript.alive)
        {
            //Aims turret based on User Input
            RotateTurret();

            //If the player inputs Spacebar
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //If the player has enough AP
                if (APScript.canAction)
                {
                    //Fire Bullet
                    Fire();
                    //Reduce AP by 1
                    APScript.ap--;
                }
            }
        }
    }

    private void RotateTurret()
    {
        //If the player inputs Up arrow key
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //Point turret Up
            Quaternion rot = Quaternion.Euler(0f, 0f, 0f);
            transform.rotation = rot;
        }
        //If the player inputs Left arrow key
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Point turret Left
            Quaternion rot = Quaternion.Euler(0f, 0f, 90f);
            transform.rotation = rot;
        }
        //If the player inputs Down arrow key
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //Point turret Down
            Quaternion rot = Quaternion.Euler(0f, 0f, 180f);
            transform.rotation = rot;
        }
        //If the player inputs Right arrow key
        else if (Input.GetKeyDown(KeyCode.RightArrow))
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
