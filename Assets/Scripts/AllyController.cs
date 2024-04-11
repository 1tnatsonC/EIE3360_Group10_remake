using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyController : MonoBehaviour
{
    public Transform player;
    public Transform target;

    public float offset = 0f;
    public Vector3 difference = Vector3.zero;
    public float speed = 2f;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float targetDistance = Vector3.Distance(transform.position + difference, target.position);
        transform.LookAt(player);

        if (targetDistance > offset)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            anim.SetBool("moving", true);
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            anim.SetBool("moving", false);
        }
    }
}
