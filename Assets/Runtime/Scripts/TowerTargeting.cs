using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class TowerTargeting : MonoBehaviour
{
    public GameObject weaponPitch;
    public GameObject weaponYaw;
    public List<GameObject> enemiesInRange = new List<GameObject>();
    public GameObject currentTarget;
    private System.Random rnd = new System.Random();
    bool targetIsActive = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TargetFirst();
        //TargetClosest();
        //TargetRandom();
        
        if (currentTarget != null)
        {
            weaponPitch.transform.forward = -weaponPitch.transform.forward;
            weaponYaw.transform.forward = -weaponYaw.transform.forward;
            weaponPitch.transform.LookAt(currentTarget.transform.position);
            weaponYaw.transform.LookAt(currentTarget.transform.position);

            
        }

        if(targetIsActive)
        {
            if (currentTarget.gameObject.IsDestroyed())
            {
                enemiesInRange.Remove(currentTarget);
                targetIsActive = false;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(other.gameObject == currentTarget.gameObject)
            {
                targetIsActive = false;
            }
            enemiesInRange.Remove(other.gameObject);
            
        }
    }

    

    private void TargetFirst()
    {
        if(enemiesInRange.Count > 0)
        {
            
            currentTarget = enemiesInRange[0];
            targetIsActive = true;
            
        }
        else
        {
            currentTarget = null;
        }
    }

    public GameObject GetCurrentTarget()
    {
        return currentTarget;
    }

    private void TargetClosest()
    {
        GameObject closestEnemy = null;
        float closestDistance = float.MaxValue;
        if(enemiesInRange.Count > 0)
        {
            foreach(GameObject enemy in enemiesInRange)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if(distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    closestEnemy = enemy;
                }
            }
        }

        if(closestEnemy != null) { currentTarget = closestEnemy; targetIsActive = true; }
        else { currentTarget = null; }

    }

    private void TargetRandom()
    {
        if(enemiesInRange.Count > 0)
        {
            int target = rnd.Next(0 , enemiesInRange.Count);
            currentTarget = enemiesInRange[target];
            targetIsActive = true;
        }
        else { currentTarget = null; }

        
    }

    
}
