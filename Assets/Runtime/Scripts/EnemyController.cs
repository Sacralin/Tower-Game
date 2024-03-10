using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private LevelManager levelManager;
    private Spawner spawner;
    public List<Transform> waypoints;
    private int currentWaypointIndex = 0;
    private float agentStoppingDistance = 0.3f;
    private bool waypointSet = false;
    private NavMeshAgent agent;
    public Slider healthBarPrefab;
    private Slider healthBar;
    public int maxHealth = 100;
    public Enemy enemy;
    private GameOver gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = FindAnyObjectByType<GameOver>();
        spawner = FindAnyObjectByType<Spawner>();
        levelManager = FindAnyObjectByType<LevelManager>();
        agent = GetComponent<NavMeshAgent>();
        healthBar = Instantiate(healthBarPrefab, this.transform.position, Quaternion.identity);
        healthBar.transform.SetParent(GameObject.Find("Canvas").transform);
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    } 

    // Update is called once per frame
    void Update()
    {
        if (!waypointSet) { return; }
        if (healthBar)
        {
            healthBar.transform.position = Camera.main.WorldToScreenPoint(this.transform.position + Vector3.up * 1.2f);
        }
        if(agent.isActiveAndEnabled)
        {
            if (!agent.pathPending && agent.remainingDistance <= agentStoppingDistance)
            {
                if (currentWaypointIndex == waypoints.Count)
                {
                    //levelManager.EnemyDestroyed();
                    if (healthBar != null)
                    {
                        Destroy(healthBar.gameObject);
                        levelManager.DecrementLives();
                        spawner.spawnedEnemies.Remove(this.gameObject);
                        gameOver.EndConditionCheck(enemy);
                    }
                    Destroy(this.gameObject, 0.1f);
                    //NPC reached the end, add lose condition

                }
                else
                {
                    agent.SetDestination(waypoints[currentWaypointIndex].position);
                    currentWaypointIndex++;
                }
            }
        }
        

    }

    public void SetDestination(List<Transform> waypoints)
    {
        this.waypoints = waypoints;
        waypointSet = true;
    }

    public void Hit(int damage)
    {
        if (healthBar)
        {
            healthBar.value -= damage;
            if(healthBar.value <= 0)
            {
                Destroy(healthBar.gameObject);
                Destroy(this.gameObject);
                //NPC dies add gold to player 
                levelManager.currentGold += enemy.goldReward;
                spawner.spawnedEnemies.Remove(this.gameObject);
                gameOver.EndConditionCheck(enemy);

            }
        }
    }
}
