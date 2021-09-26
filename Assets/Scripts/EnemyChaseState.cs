using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseState : EnemyBaseState
{
    private NavMeshAgent agent;
    private float originalSpeed;
    private float originalAngularSpeed;

    private int unseenCount = 30;
    private int currCount;

    public override void EnterState(EnemyController enemy)
    {
        Debug.Log("chasing");
        agent = enemy.GetComponent<NavMeshAgent>();

        originalSpeed = agent.speed;
        originalAngularSpeed = agent.angularSpeed;
        agent.speed = enemy.chaseSpeed;
        agent.angularSpeed = enemy.chaseAngularSpeed;
        // set destination as the player position (the only target)
        agent.SetDestination(enemy.target.transform.position);

        currCount = 0;
    }

    public override void Update(EnemyController enemy)
    {
        if (enemy.playerInSight || ++currCount < unseenCount)
        {
            agent.SetDestination(enemy.target.transform.position);
        }
        else
        {
            agent.isStopped = true;
            agent.ResetPath();
            agent.speed = originalSpeed;
            agent.angularSpeed = originalAngularSpeed;
            enemy.TransitionToState(enemy.ObservingState);
        }
    }
}
