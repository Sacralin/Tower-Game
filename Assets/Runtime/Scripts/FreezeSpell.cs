using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class FreezeSpell : MonoBehaviour
{
    Spawner spawner;
    public Button freezeButton;
    LevelManager levelManager;
    float spellCost = 50;
    float duration = 3f;
    float timer = 0f;
    bool freezeActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        spawner = FindAnyObjectByType<Spawner>();
        levelManager = FindAnyObjectByType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spellCost <= levelManager.currentGold)
        {
            freezeButton.image.color = Color.white;
        }
        else
        {
            freezeButton.image.color = Color.red;
        }

        if (freezeActivated)
        {
            timer += Time.deltaTime;
            if(timer >= duration)
            {
                DisableFreeze();
            }
        }
        
    }

    public void FreezeButtonPressed()
    {
        if (spellCost <= levelManager.currentGold)
        {
            foreach (GameObject enemy in spawner.spawnedEnemies)
            {
                NavMeshAgent navmesh = enemy.GetComponent<NavMeshAgent>();
                navmesh.enabled = false;
            }
            freezeActivated = true;
            timer = 0f;
            levelManager.currentGold -= spellCost;
        }
    }

    private void DisableFreeze()
    {
        foreach (GameObject enemy in spawner.spawnedEnemies)
        {
            NavMeshAgent navmesh = enemy.GetComponent<NavMeshAgent>();
            navmesh.enabled = true;
        }
        freezeActivated = false;
    }

}
