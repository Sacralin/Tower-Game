using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the arrow collided with something other than the shooter
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            if(enemy != null)
            {
                enemy.Hit(damage);
            }
            
        }

        if (!collision.gameObject.CompareTag("Tower"))
        {
            // Destroy the arrow projectile
            Destroy(gameObject);
        }

    }
}
