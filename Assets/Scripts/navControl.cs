using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navControl : MonoBehaviour
{

    public GameObject Target;
    private NavMeshAgent agent;
    bool isWalking = true;
    private Animator animator;
    public Transform face;
    bool lookathim;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking) 
        {
            agent.destination = Target.transform.position;
        }
        else
        {
            agent.destination = transform.position;
            
        }
        if (lookathim)
        {
            gameObject.transform.LookAt(face);
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Dragon")
        {
            lookathim = true;
            isWalking = false;
            animator.SetTrigger("ATTACK");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Dragon")
        {
            lookathim = false;
            isWalking = true;
            animator.SetTrigger("WALK");
        }
    }
}
