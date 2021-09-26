using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyInvestigateState : EnemyBaseState
{
    private NavMeshAgent agent;

    private int waitCount = 30;
    private int currCount;

    public override void EnterState(EnemyController enemy)
    {
        Debug.Log("investigating");

        agent = enemy.GetComponent<NavMeshAgent>();
        agent.SetDestination(enemy.positionToInvestigate);

        currCount = 0;
    }

    public override void Update(EnemyController enemy)
    {
        if (enemy.chasingPlayer)
        {
            enemy.TransitionToState(enemy.ChaseState);
        }
        if (agent.velocity == Vector3.zero && ++currCount > waitCount)
        {
            enemy.TransitionToState(enemy.ObservingState);
        }
        if (!agent.hasPath && agent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            agent.enabled = false;
            agent.enabled = true;
        }
    }
}
