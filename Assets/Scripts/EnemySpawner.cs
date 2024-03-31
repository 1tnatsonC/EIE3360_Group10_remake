using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private EnemyHealth enemyPrefab;
    [SerializeField] private float spawnInterval;
    [SerializeField] private int maxEnemiesNumber;
    [SerializeField] private Player player;

    private List<EnemyHealth> spawnedEnemies = new List<EnemyHealth>();
    private float timeSinceLastSpawn;

	

    private void Start()
    {
        timeSinceLastSpawn = spawnInterval;
    }

    public void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn > spawnInterval)
        {
            timeSinceLastSpawn = 0f;
            if (spawnedEnemies.Count < maxEnemiesNumber)
            {
                SpawnEnemy();
				Debug.Log(spawnedEnemies.Count);
            }
        }
        
    }

    private void SpawnEnemy()
    {
        EnemyHealth enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
        int spawnPointindex = spawnedEnemies.Count % spawnPoints.Length;
        enemy.Init(player, spawnPoints[spawnPointindex]);
        spawnedEnemies.Add(enemy);
    }
}
