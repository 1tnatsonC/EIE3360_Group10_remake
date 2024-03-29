using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public int bulletDamage = 10; // Set the damage dealt by the bullet

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Apply damage to the enemy
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(bulletDamage);
            }

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
