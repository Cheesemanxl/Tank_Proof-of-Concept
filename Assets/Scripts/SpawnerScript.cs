using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject targetPrefab;

    private Vector3 pos;
    private Vector3 rot;

    private int intx;
    private int inty;
    private int count;

    private float newx;
    private float newy;

    void Start()
    {
        SpawnTarget();
    }

    void Update()
    {
        //count is less than 288
        if (count < 576)
        {
            //add 1 to count
            count++;
        }
        //count is above 288
        else
        {
            //Spawn a prefab of the target
            SpawnTarget();
            //Reset Count To Zero
            count = 0;
        }
    }

    void SpawnTarget()
    {
        //pick a random integer in the screen range
        intx = Random.Range(-9, 8);
        inty = Random.Range(-5, 4);

        //align tiles with tank position
        pos.x = intx + 0.5f;
        pos.y = inty + 0.5f;
        pos.z = 0;

        //create deafualt rotation to fill into instantiate
        Quaternion rot = Quaternion.Euler(0f, 0f, 0f);

        //spawn a Target prefab
        Instantiate(targetPrefab, pos, rot);
    }
}
