using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Assign your bullet prefab in the Inspector
    public Transform bulletSpawnPoint; // Assign the spawn point in the Inspector
    public float bulletSpeed = 20f;
    public float shootingInterval = 2f; // Time between shots
    private float nextShootTime;
    public Transform playerTransform; // Reference to the player's transform

    void Start()
    {
        // Assign the player's transform (you can do this via tags or other methods)
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Check if it's time to shoot again
        if (Time.time > nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + shootingInterval;
        }
    }

    void Shoot()
    {
        // Calculate the aim direction
        Vector3 playerDirection = (playerTransform.position - transform.position).normalized;

        // Set the bullet rotation based on the aim direction
        Quaternion bulletRotation = Quaternion.LookRotation(playerDirection);

        // Instantiate the bullet
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletRotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        // Optional: Destroy the bullet after a certain time to avoid memory leaks
        Destroy(bullet, 2f);
    }
}
