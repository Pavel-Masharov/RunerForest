using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : Enemy
{

    private void Update()
    {
        MoveEnemy();
        DestroyEnemy();
    }

}
