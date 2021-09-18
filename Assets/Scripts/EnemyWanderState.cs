using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWanderState : EnemyBaseState
{
    private List<Vector3> wanderCoordinates;
    private NavMeshAgent agent;

    private int nextPosition = 0;

    public override void EnterState(EnemyController enemy)
    {
        wanderCoordinates = enemy.wanderCoordinates;
        agent = enemy.GetComponent<NavMeshAgent>();

        nextPosition = nextPosition + 1 < wanderCoordinates.Count ? nextPosition + 1 : 0;
        agent.SetDestination(wanderCoordinates[nextPosition]);
    }

    public override void Update(EnemyController enemy)
    {
        if (agent.velocity == Vector3.zero)
        {
            enemy.TransitionToState(enemy.ObservingState);
        }
    }
}
