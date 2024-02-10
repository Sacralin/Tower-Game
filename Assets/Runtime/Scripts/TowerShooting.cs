using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : MonoBehaviour
{
    private TowerTargeting targeting;
    private GameObject currentTarget;
    private string type;
    private int level = 1;
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
            type = "ballista"; 
            selectedProjectile = arrowProjectilePrefab;
            attackSpeed = 2f;
            projectileSpeed = 2f;
        }
        else if (this.gameObject.name.Contains("cannon")) 
        { 
            type = "cannon"; 
            selectedProjectile = cannonProjectilePrefab;
            attackSpeed = 2f;
            projectileSpeed = 2f;
        }
        else if (this.gameObject.name.Contains("poison")) 
        { 
            type = "magic"; 
            selectedProjectile = magicProjectilePrefab;
            attackSpeed = 2f;
            projectileSpeed = 2f;
        }
        else { Debug.Log("Tower type unknown"); }
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(attackSpeed);
        //Debug.Log(attackIntervalCounter);
        targeting.currentTarget = currentTarget;
        Debug.Log(currentTarget);
        Debug.Log(targeting.currentTarget);
        attackIntervalCounter += 1 * Time.deltaTime;
        if(attackIntervalCounter >= attackSpeed)
        {
            attackIntervalCounter = attackSpeed;
        }
        
        if(currentTarget != null && attackIntervalCounter == attackSpeed )
        {
            Debug.Log("test");
            FireProjectile();
        }
    }

    private void FireProjectile()
    {
        GameObject newProjectile = Instantiate(selectedProjectile, firePoint.position, Quaternion.identity);
        newProjectile.GetComponent<Rigidbody>().velocity = firePoint.forward * projectileSpeed;
    }
}
