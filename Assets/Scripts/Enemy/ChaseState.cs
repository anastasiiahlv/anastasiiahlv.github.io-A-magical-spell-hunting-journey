using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent.speed = 2.5f;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.position);
        float distance = Vector3.Distance(player.position, animator.transform.position);

        if (distance <= 2.5f)
        {
            animator.SetBool("IsAttacking", true);
            animator.SetBool("IsChasing", false);
            return;
        }

        if (distance > 15f)
        {
            animator.SetBool("IsChasing", false);
            animator.SetBool("IsPatrolling", true);
            return;
        }

        animator.SetBool("IsAttacking", false);
        animator.SetBool("IsChasing", true);
        agent.SetDestination(player.position);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }
}
