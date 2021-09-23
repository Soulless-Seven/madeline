using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObservingState : EnemyBaseState
{
    private float observeRotation;
    private float rotateSpeed;
    private float observeTime;
    private float currTime;

    public override void EnterState(EnemyController enemy)
    {
        Debug.Log("observing");
        observeRotation = enemy.observeRotation;
        rotateSpeed = enemy.rotateSpeed;
        observeTime = enemy.observeTime;
        currTime = 0;
    }

    public override void Update(EnemyController enemy)
    {
        enemy.transform.rotation = Quaternion.Euler(0f, observeRotation * Mathf.Sin(Time.time * rotateSpeed), 0f);

        currTime += Time.deltaTime;

        if (enemy.chasingPlayer) 
        {
            enemy.TransitionToState(enemy.ChaseState);
        }
        if (currTime > observeTime)
        {
            enemy.TransitionToState(enemy.WanderState);
        }
    }
}
