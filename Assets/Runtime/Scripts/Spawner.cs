using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<Transform> waypoints;
    public float spawnRate = 0.5f;
    public int maxCount = 10;
    private int count = 0;

    void Spawn()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemy.GetComponent<EnemyController>().SetDestination(waypoints);
        count++;
        if(count >= maxCount)
        {
            CancelInvoke();
        }
    }

    public void StartNextWave()
    {
        count = 0;
        InvokeRepeating("Spawn", 1, spawnRate);
    }

    public void StopSpawning()
    {
        CancelInvoke();
    }
}
