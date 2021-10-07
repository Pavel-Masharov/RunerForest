using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : Enemy
{
    private Vector3 startPos;
   
    void Start()
    {
        startPos = transform.position;

       
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
        if (transform.position.z < - 18f)
        {
            transform.position = startPos;
        }
    }
}
