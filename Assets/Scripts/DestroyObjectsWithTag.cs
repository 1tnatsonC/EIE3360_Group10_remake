using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectsWithTag : MonoBehaviour
{
    private void Start()
    {
        // Find all objects with the tag "BloodEffect"
        GameObject[] bloodEffects = GameObject.FindGameObjectsWithTag("BloodEffect");

        // Destroy each object
        foreach (GameObject bloodEffect in bloodEffects)
        {
            Destroy(bloodEffect);
        }
    }
}
