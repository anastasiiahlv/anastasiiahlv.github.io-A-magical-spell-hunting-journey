using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    float attackCooldown = 1.5f;
    float lastAttackTime;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        lastAttackTime = Time.time;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 lookPos = player.position - animator.transform.position;
        lookPos.y = 0;
        if (lookPos != Vector3.zero)
            animator.transform.forward = lookPos.normalized;

        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance > 3.5f)
        {
            animator.SetBool("IsAttacking", false);
            return;
        }

        if (Time.time >= lastAttackTime + attackCooldown)
        {
            playerHealth.TakeDamage(20);
            lastAttackTime = Time.time;
        }
    }
}
