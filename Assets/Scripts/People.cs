using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : Enemy
{
    [SerializeField] private GameObject bulletPrefab;
    private GameObject bullet;
    private void Update()
    {
        MoveEnemy();
        DestroyEnemy();
        GunEnemy();
    }

    private void GunEnemy()
    {
        Ray ray = new Ray(transform.position,Vector3.back);
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.back, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if(hitObject.GetComponent<Player>())
            {
                if (bullet == null)
                {
                    bullet = Instantiate(bulletPrefab);
                    bullet.transform.position = transform.TransformPoint(Vector3.back * 1.5f);
                }
            }
        }
    }


}
