using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class PatrolState : StateMachineBehaviour
{
    float timer;
    List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent agent;
    Transform player;
    float chaseRange = 8;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 1.5f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timer = 0;
        GameObject go = GameObject.FindGameObjectWithTag("Waypoint");
        foreach(Transform t in go.transform)
            wayPoints.Add(t);

        agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(agent.remainingDistance <= agent.stoppingDistance)
            agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);

        timer += Time.deltaTime;
        if (timer > 10)
            animator.SetBool("IsPatrolling", false);

        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance < chaseRange)
            animator.SetBool("IsChasing", true);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }
}
