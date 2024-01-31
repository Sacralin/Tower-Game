using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public List<Transform> waypoints;
    private int currentWaypointIndex = 0;
    private float agentStoppingDistance = 0.3f;
    private bool waypointSet = false;
    private NavMeshAgent agent;
    public LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        levelManager = FindAnyObjectByType<LevelManager>();
    } 

    // Update is called once per frame
    void Update()
    {
        if (!waypointSet) { return; }
        if(!agent.pathPending && agent.remainingDistance <= agentStoppingDistance)
        {
            if(currentWaypointIndex == waypoints.Count)
            {
                levelManager.EnemyDestroyed();
                Destroy(this.gameObject, 0.1f);
            }
            else
            {
                agent.SetDestination(waypoints[currentWaypointIndex].position);
                currentWaypointIndex++;
            }
        }

    }

    public void SetDestination(List<Transform> waypoints)
    {
        this.waypoints = waypoints;
        waypointSet = true;
    }
}
