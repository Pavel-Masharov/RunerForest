using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Enemy
{
    [SerializeField] private float speedBulett = 2f;
    void Update()
    {
        MoveEnemy();
        DestroyEnemy();
    }
    public override void MoveEnemy()
    {
        if (GameManager.isGameOver == false)
        {
            transform.Translate(Vector3.back * Time.deltaTime * GameManager.speedEnemy * speedBulett);
        }
    }
}
