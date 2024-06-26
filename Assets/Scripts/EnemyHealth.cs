using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    [SerializeField] private ParticleSystem bloodSplatterFX;

    const string RUN_TRIGGER = "Run";
    const string CROUCH_TRIGGER = "Crouch";
    const string SHOOT_TRIGGER = "Shoot";

    private Animator animator;
    private NavMeshAgent agent;


    private Transform occupiedCoverSpot;
    private Player player;
    private bool isShooting;

    [SerializeField] private float minTimeUnderCover;
    [SerializeField] private float maxTimeUnderCover;
    [SerializeField] private int minShotsToTake;
    [SerializeField] private int maxShotsToTake;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float damage;
    [Range(0, 100)]
    [SerializeField] private float shootingAccuracy;
    private int currentShotsTaken;
    private int currentMaxShotsToTake;

    private static int defeatedEnemiesCount = 0;

    [SerializeField] private AudioSource hurtAudioSource;
    [SerializeField] private AudioSource deathAudioSource;
    

    private void Awake()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        animator.SetTrigger(RUN_TRIGGER);
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Instantiate(bloodSplatterFX, transform.position, Quaternion.identity);
        hurtAudioSource.Play();	
        
        if (currentHealth <= 0)
        {
            //deathAudioSource.Play();
            OnEnemyDefeated(); // Call the Die method when health reaches zero or below
            
        }
    }

    public void DestroyBloodSplatterFXWithTag()
    {
        GameObject[] bloodSplatters = GameObject.FindGameObjectsWithTag("BloodEffect");
        
        foreach (GameObject bloodSplatter in bloodSplatters)
        {
            Destroy(bloodSplatter);
        }
    }

    public void OnEnemyDefeated()
    {
        // Play the blood splatter effect on the enemy game object...
        Instantiate(bloodSplatterFX, transform.position, Quaternion.identity);
        //deathAudioSource.Play();
        Destroy(gameObject); // Destroy the enemy game object
        DestroyBloodSplatterFXWithTag();

        defeatedEnemiesCount++; // Increment the defeated enemies count
        //Debug.Log(defeatedEnemiesCount);

        // Check if defeatedEnemiesCount reaches 7
        if (defeatedEnemiesCount >= 7)
        {
            // Load the next scene (replace "NextSceneName" with your actual scene name)
            SceneManager.LoadScene("Ending Scene");
        }
    }



    public void Init(Player player, Transform coverSpot)
    {
        occupiedCoverSpot = coverSpot;
        this.player = player;
        GetToCover();
    }


    private void GetToCover()
    {
        agent.isStopped = false;
        agent.SetDestination(occupiedCoverSpot.position);
    }


    private void Update()
    {
        if (player == null)
            return;
            
        if(agent.isStopped == false && (transform.position - occupiedCoverSpot.position).sqrMagnitude <= 0.1f)
        {
            agent.isStopped = true;
            StartCoroutine(InitializeShootingCO());
        }
        if (isShooting)
        {
            RotateTowardsPlayer();
        }
    }

    private IEnumerator InitializeShootingCO()
    {
        HideBehindCover();
        yield return new WaitForSeconds(UnityEngine.Random.Range(minTimeUnderCover, maxTimeUnderCover));
        StartShooting();
    }

    private void HideBehindCover()
    {
        animator.SetTrigger(CROUCH_TRIGGER);
    }
    private void StartShooting()
    {
        isShooting = true;
        currentMaxShotsToTake = UnityEngine.Random.Range(minShotsToTake, maxShotsToTake);
        currentShotsTaken = 0;
        animator.SetTrigger(SHOOT_TRIGGER);

        // Reduce player's health (modify the damage value as needed)
        //player.TakeDamage(damage);

        float randomAccuracy = UnityEngine.Random.Range(0f, 100f);

        // Check if the shot hits based on shooting accuracy
        //if (randomAccuracy <= shootingAccuracy)
        //{
            // Reduce player's health (modify the damage value as needed)
            //player.TakeDamage(damage);
        //}
        //else
        //{
            // Shot missed (you can add visual/audio feedback for misses if desired)
           // Debug.Log("Shot missed!");
       //}


    }

    private void RotateTowardsPlayer()
    {
        Vector3 direction = player.GetHeadPosition() - transform.position;
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        transform.rotation = rotation;
    }   
    
}
