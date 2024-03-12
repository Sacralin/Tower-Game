using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : MonoBehaviour
{
    private SoundPlayer soundPlayer;
    private TowerTargeting targeting;
    private GameObject currentTarget;
    private string type;
    //private int level = 1;
    private float attackSpeed = 2f;
    public GameObject arrowProjectilePrefab;
    public GameObject cannonProjectilePrefab;
    public GameObject magicProjectilePrefab;
    private GameObject selectedProjectile;
    private float projectileSpeed;
    private float attackIntervalCounter;
    public Transform firePoint;
    private int damage;


    // Start is called before the first frame update
    void Start()
    {
        soundPlayer = FindAnyObjectByType<SoundPlayer>();
        targeting = GetComponent<TowerTargeting>();
        if (this.gameObject.name.Contains("ballista")) 
        { 
            type = "ballista"; 
            selectedProjectile = arrowProjectilePrefab;
            attackSpeed = 1f;
            projectileSpeed = 20f;

            if (this.gameObject.name.Contains("1")) //level 1
            {
                damage = 3;
            }
            else if (this.gameObject.name.Contains("2")) //level 2
            {
                damage = 3;
                attackSpeed = attackSpeed / 2 ;
            }
            else if (this.gameObject.name.Contains("3")) //level 3
            {
                damage = 3;
                attackSpeed = (attackSpeed / 2) /2 ;
            }
            else if (this.gameObject.name.Contains("4")) //level 4
            {
                damage = 6;
                attackSpeed = (attackSpeed / 2) / 2;
            }
        }
        else if (this.gameObject.name.Contains("cannon")) 
        { 
            type = "cannon"; 
            selectedProjectile = cannonProjectilePrefab;
            attackSpeed = 3f;
            projectileSpeed = 20f;

            if (this.gameObject.name.Contains("1"))
            {
                damage = 4;
            }
            else if (this.gameObject.name.Contains("2"))
            {
                damage = 8;
            }
            else if (this.gameObject.name.Contains("3"))
            {
                damage = 12;
            }
            else if (this.gameObject.name.Contains("4"))
            {
                damage = 16;
            }
        }
        else if (this.gameObject.name.Contains("poison")) 
        { 
            type = "magic"; 
            selectedProjectile = magicProjectilePrefab;
            attackSpeed = 2f;
            projectileSpeed = 20f;

            if (this.gameObject.name.Contains("1"))
            {
                damage = 2;
            }
            else if (this.gameObject.name.Contains("2"))
            {
                damage = 4;
            }
            else if (this.gameObject.name.Contains("3"))
            {
                damage = 6;
            }
            else if (this.gameObject.name.Contains("4"))
            {
                damage = 8;
            }

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

        Projectile script = newProjectile.GetComponent<Projectile>();

        script.damage = damage;

        // Calculate the direction from the firePoint to the target
        Vector3 direction = (currentTarget.transform.position - firePoint.position).normalized;

        // Calculate the rotation needed to face the target
        Quaternion rotation = Quaternion.LookRotation(direction);

        // Rotate the projectile to face the target
        newProjectile.transform.rotation = rotation;

        // Adjust projectile to point toward the target
        newProjectile.transform.localEulerAngles = new Vector3(newProjectile.transform.localEulerAngles.x + 90f,
                                                               newProjectile.transform.localEulerAngles.y, 
                                                               newProjectile.transform.localEulerAngles.z);

        // Apply the calculated direction to the projectile's Rigidbody
        Rigidbody rb = newProjectile.GetComponent<Rigidbody>();
        rb.velocity = direction * projectileSpeed;

        PlaySound();
    }

    private void PlaySound()
    {
        switch (type)
        {
            case "ballista":
                soundPlayer.PlayArrowSound();
                break;
            case "cannon":
                soundPlayer.PlayCannonSound();
                break;
            case "magic":
                soundPlayer.PlayMagicSound();
                break;
                default: break;

        }
    }


}
