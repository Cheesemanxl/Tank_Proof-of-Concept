using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankScript : MonoBehaviour
{
    private float speed = 1.0f;
    private Vector3 pos;
    public EnemyAPScript APScript;
    private int count = 0;

    private bool lookUp = true;
    private bool lookDown = false;
    private bool lookLeft = false;
    private bool lookRight = false;

    void Start()
    {
        //Set position vector to the current character position
        pos = transform.position;
    }

    void Update()
    {
        if (count > 288)
        {
            count++;
        }
        else
        {
            //Recieve player input and choose direction
            DecideDirection();

            //Move Player Towards Decided Direction
            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
            count = 0;
        }
    }

    void DecideDirection()
    {
        int choice = Random.Range(0, 3);

        //If the character has not yet moved
        if (APScript.ap > 0)
        {
            //If the player inputs W
            if (choice == 0)
            {
                //if not looking Up
                if (lookUp == false)
                {
                    //look towards Up
                    Quaternion rot = Quaternion.Euler(0f, 0f, 0f);
                    transform.rotation = rot;

                    //update bools
                    lookUp = true;
                    lookLeft = false;
                    lookDown = false;
                    lookRight = false;
                }
                //if looking Up
                else
                {
                    //If the player has enough AP
                    if (APScript.canAction)
                    {
                        if (transform.position.y < 4)
                        {
                            //Move Up
                            pos += Vector3.up;
                            //Reduce AP by 1
                            APScript.ap--;
                        }
                    }
                }
            }
            //If the player inputs A
            else if (choice == 1)
            {
                //if not looking left
                if (lookLeft == false)
                {
                    //look towards the left
                    Quaternion rot = Quaternion.Euler(0f, 0f, 90f);
                    transform.rotation = rot;

                    //update bools
                    lookUp = false;
                    lookLeft = true;
                    lookDown = false;
                    lookRight = false;
                }
                //if looking left
                else
                {
                    //If the player has enough AP
                    if (APScript.canAction)
                    {
                        if (transform.position.x > -8)
                        {
                            //Move Left
                            pos += Vector3.left;
                            //Reduce AP by 1
                            APScript.ap--;
                        }
                    }
                }
            }
            //If the player inputs S
            else if (choice == 2)
            {
                //if not looking down
                if (lookDown == false)
                {
                    //look down
                    Quaternion rot = Quaternion.Euler(0f, 0f, 180f);
                    transform.rotation = rot;

                    //update bools
                    lookUp = false;
                    lookLeft = false;
                    lookDown = true;
                    lookRight = false;
                }
                //if looking down
                else
                {
                    //If the player has enough AP
                    if (APScript.canAction)
                    {
                        if (transform.position.y > -4)
                        {
                            //Move down
                            pos += Vector3.down;
                            //Reduce AP by 1
                            APScript.ap--;
                        }
                    }
                }
            }
            //If the player inputs D
            else if (choice == 3)
            {
                //if not looking right
                if (lookRight == false)
                {
                    //look towards the right
                    Quaternion rot = Quaternion.Euler(0f, 0f, 270f);
                    transform.rotation = rot;

                    //update bools
                    lookUp = false;
                    lookLeft = false;
                    lookDown = false;
                    lookRight = true;
                }
                //if looking right
                else
                {
                    //If the player has enough AP
                    if (APScript.canAction)
                    {
                        if (transform.position.x < 8)
                        {
                            //Move Right
                            pos += Vector3.right;
                            //Reduce AP by 1
                            APScript.ap--;
                        }
                    }
                }
            }
        }
    }
}
