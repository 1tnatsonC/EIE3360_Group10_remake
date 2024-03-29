using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject player;
    public GameObject pistol;
    public Transform shootPoint; // The position from where bullets will be fired
    public float fireSpeed = 20; // Speed of the bullet
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public float fireRate = 1.0f; // Rate of fire (bullets per second)
    private float nextFireTime = 0.0f;

    void Update()
    {
        // Aim at the player
        Vector3 difference = player.transform.position - pistol.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        pistol.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        // Check if enough time has passed since the last shot
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + 1.0f / fireRate; // Set the fire rate
            FireBullet();
        }
    }

    void FireBullet()
    {
        GameObject spawnBullet = Instantiate(bulletPrefab);
        spawnBullet.transform.position = shootPoint.position;
        spawnBullet.GetComponent<Rigidbody>().velocity = shootPoint.forward * fireSpeed;

        // Attach the BulletCollision script to the bullet
        BulletCollision bulletCollision = spawnBullet.GetComponent<BulletCollision>();
        if (bulletCollision != null)
        {
            bulletCollision.bulletDamage = 10; // Set the damage value
        }

        Destroy(spawnBullet, 5); // Destroy the bullet after some time
    }
}
