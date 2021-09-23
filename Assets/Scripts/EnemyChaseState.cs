using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseState : EnemyBaseState
{
    private NavMeshAgent agent;

    private int unseenCount = 30;
    private int currCount;

    public override void EnterState(EnemyController enemy)
    {
        Debug.Log("chasing");
        agent = enemy.GetComponent<NavMeshAgent>();
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
            enemy.TransitionToState(enemy.ObservingState);
        }
    }
}
