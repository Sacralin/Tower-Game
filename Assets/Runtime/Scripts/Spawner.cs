using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private WaveComposition wave;
    private Enemy enemy;
    private float timeToFirstWaveSpawn = 5f;
    public List<Enemy> spawnedEnemies = new List<Enemy>();
    private float timer;
    private float timeTillNextEnemySpawn;
    private bool beginSpawning;
    public List<Transform> waypoints;
    public List<Transform> flightWaypoints;
    private bool nextSpawnTimerSet;

    private void Awake()
    {
        wave = new WaveComposition();
        wave.Level1WaveComposition();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeToFirstWaveSpawn)
        {
            beginSpawning = true;
        }

        ManageSpawnDelay();

        if (beginSpawning && timer >= timeTillNextEnemySpawn)
        {
            Spawn();
        }
    }

    private void ManageSpawnDelay()
    {
        if (wave.wave.Count != 0 && nextSpawnTimerSet == false)
        {
            enemy = wave.wave[0];
            timeTillNextEnemySpawn = enemy.timeTillNextSpawn;
            nextSpawnTimerSet = true;
        }
    }

    private void Spawn()
    {
        if(wave.wave.Count != 0)
        {
            GameObject enemyPrefab = Instantiate(enemy.selectedPrefab, transform.position, Quaternion.identity);
            EnemyController controller = enemyPrefab.GetComponent<EnemyController>();
            if(enemy.type == "dragon")
            {
                controller.SetDestination(flightWaypoints);
            }
            else
            {
                controller.SetDestination(waypoints);
            }
            controller.maxHealth = enemy.health;
            controller.enemy = enemy;
            spawnedEnemies.Add(enemy);
            wave.wave.Remove(enemy);
            nextSpawnTimerSet = false;
            timer = 0;
        }
    }
}
