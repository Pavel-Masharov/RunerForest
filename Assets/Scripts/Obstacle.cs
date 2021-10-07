using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Enemy
{
    private void Update()
    {
        MoveEnemy();
        DestroyEnemy();
    }
}
