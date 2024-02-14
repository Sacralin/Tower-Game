using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : MonoBehaviour
{
    private TowerTargeting targeting;
    private GameObject currentTarget;
    //private string type;
    //private int level = 1;
    private float attackSpeed = 2f;
    public GameObject arrowProjectilePrefab;
    public GameObject cannonProjectilePrefab;
    public GameObject magicProjectilePrefab;
    private GameObject selectedProjectile;
    private float projectileSpeed;
    private float attackIntervalCounter;
    public Transform firePoint;


    // Start is called before the first frame update
    void Start()
    {
        targeting = GetComponent<TowerTargeting>();
        if (this.gameObject.name.Contains("ballista")) 
        { 
            //type = "ballista"; 
            selectedProjectile = arrowProjectilePrefab;
            attackSpeed = 1f;
            projectileSpeed = 20f;
        }
        else if (this.gameObject.name.Contains("cannon")) 
        { 
            //type = "cannon"; 
            selectedProjectile = cannonProjectilePrefab;
            attackSpeed = 3f;
            projectileSpeed = 50f;
        }
        else if (this.gameObject.name.Contains("poison")) 
        { 
            //type = "magic"; 
            selectedProjectile = magicProjectilePrefab;
            attackSpeed = 2f;
            projectileSpeed = 20f;
        }
        else { Debug.Log("Tower type unknown"); }
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTarget = targeting.GetCurrentTarget();
        attackIntervalCounter += Time.deltaTime;

        if (currentTarget != null && attackIntervalCounter >= attackSpeed)
        {
            FireProjectile();
            attackIntervalCounter = 0f; // Reset the counter after firing
        }
    }



    private void FireProjectile()
    {
        GameObject newProjectile = Instantiate(selectedProjectile, firePoint.position, Quaternion.identity);
        
        // Calculate the direction from the firePoint to the target
        Vector3 direction = (currentTarget.transform.position - firePoint.position).normalized;

        // Calculate the rotation needed to face the target
        Quaternion rotation = Quaternion.LookRotation(direction);

        // Rotate the projectile to face the target
        newProjectile.transform.rotation = rotation;

        // Apply the calculated direction to the projectile's Rigidbody
        Rigidbody rb = newProjectile.GetComponent<Rigidbody>();
        rb.velocity = direction * projectileSpeed;
    }


}
