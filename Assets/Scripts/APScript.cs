using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class APScript : MonoBehaviour
{
    public int ap = 2;
    public bool canAction = true;
    private int count = 0;
    public static Text apText;

    void Start()
    {
        apText = GameObject.FindGameObjectWithTag("APText").GetComponent<Text>();
        apText.text = "AP: " + ap + "/2";

    }

    void Update()
    {
        //if ap is zero
        if (ap == 0)
        {
            //start gaining ap
            GainAP();
            //set can action bool to false making the player unable to move and shoot
            canAction = false;
        }
        //if ap is 1
        else if (ap == 1)
        {
            //start gaining ap
            GainAP();
            //set can action bool to true allowing the player to move and shoot
            canAction = true;
        }
        //if ap is 2
        else if (ap == 2)
        {
            //set can action bool to true allowing the player to move and shoot
            canAction = true;
        }

        apText.text = "AP: " + ap + "/2";
    }

    //Count through frames until 2 seconds have passed and then gain 1 ap
    void GainAP()
    {
        //count is less than 288
        if (count < 288)
        {
            //add 1 to count
            count ++;
        }
        //count is above 288
        else
        {
            //add 1 to ap
            ap++;

            //set count back to 0
            count = 0;
        }
    }
}
