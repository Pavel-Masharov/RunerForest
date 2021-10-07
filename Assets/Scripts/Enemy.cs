using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public virtual void MoveEnemy()
    {
        if(GameManager.isGameOver == false)
        {
            transform.Translate(Vector3.back * Time.deltaTime * GameManager.speedEnemy);
        }
    }
    protected void DestroyEnemy()
    {
        if(transform.position.z < -15)
        {
            Destroy(gameObject);
        }
    }

}
