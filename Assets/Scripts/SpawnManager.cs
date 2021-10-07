using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemyPreffabs;

    private float minSpawnTime = 2.0f;
    private float maxSpawnTime = 5.0f;

    private int spawnPosY = 0;
    private int spawnPosZ = 20;

    public void StartSpawnEnemy()
    {
        StartCoroutine(SpawnEnemy());
    }

    private Enemy SelectEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPreffabs.Count);
        return enemyPreffabs[enemyIndex];
    }
    private Vector3 GenerateSpawnPosition()
    {
        float[] spawnRangeX = { -1.5f, 0, 1.5f };
        int indPosX = Random.Range(0, spawnRangeX.Length);

       
        Vector3 randomPos = new Vector3(spawnRangeX[indPosX], spawnPosY, spawnPosZ);
        return randomPos;
    }

    private float GenerateSpawnTime()
    {
        float timeSpawn = Random.Range(minSpawnTime, maxSpawnTime);
        return timeSpawn;
    }
    private IEnumerator SpawnEnemy()
    {
        while(GameManager.isGameOver == false)
        {
            yield return new WaitForSeconds(GenerateSpawnTime());
            Instantiate(SelectEnemy(), GenerateSpawnPosition(), SelectEnemy().transform.rotation);
        } 
    }
}
