using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseState : EnemyBaseState
{
    private NavMeshAgent agent;

    private int unseenCount = 60;
    private int currCount;

    public override void EnterState(EnemyController enemy)
    {
        Debug.Log("chasing");
        agent = enemy.GetComponent<NavMeshAgent>();
        // set destination as the target/player position
        agent.SetDestination(enemy.visibleTargets[0].position);

        currCount = 0;
    }

    public override void Update(EnemyController enemy)
    {
        if (enemy.visibleTargets.Count > 0 || ++currCount < unseenCount)
        {
            agent.SetDestination(enemy.visibleTargets[0].position);
        }
        else
        {
            enemy.TransitionToState(enemy.ObservingState);
        }
    }
}
