using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetTest : MonoBehaviour
{
    public List<Vector3> runCoordinates;
    public GameObject enemy;

    private EnemyController enemyController;
    private NavMeshAgent agent;
    private int nextPosition = 0;
    private bool beingChased = false;

    void Start()
    {
        enemyController = enemy.GetComponent<EnemyController>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        beingChased = enemyController.chasingPlayer;

        if (!agent.pathPending && beingChased)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    nextPosition = nextPosition + 1 < runCoordinates.Count ? nextPosition + 1 : 0;
                    agent.SetDestination(runCoordinates[nextPosition]);
                }
            }
        }
    }
}
