using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] Transform head;

    public void TakeDamage(float damage)
    {
        health -= damage;
        GetComponent<AudioSource>().Play();	
        Debug.LogError(string.Format("Player health: {0}",health));

        //if (health <= 30)
        //{
            // Load the next scene (replace "NextSceneName" with your actual scene name)
            //SceneManager.LoadScene("3rd Scene(Shooting)");
        //}
    }

    public Vector3 GetHeadPosition()
    {
        return head.position;
    }
}
