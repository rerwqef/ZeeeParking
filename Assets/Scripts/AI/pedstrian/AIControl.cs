using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour {

    private GameObject[] goalLocations;
    NavMeshAgent agent;
    Animator anim;
    void Start() {

        agent = this.GetComponent<NavMeshAgent>();
        goalLocations = GameObject.FindGameObjectsWithTag("goal");
        int i= Random.Range(0, goalLocations.Length);
        agent.SetDestination(goalLocations[i].transform.position);
        anim=this.GetComponent<Animator>();
        anim.SetTrigger("isWalking");
      
    }


    void Update() {
        if (agent.remainingDistance < 0.1f)
        {
            int i=Random.Range(0, goalLocations.Length);
            agent.SetDestination(goalLocations[i].transform.position);
        }
    }
}