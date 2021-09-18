using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObservingState : EnemyBaseState
{
    private float observeRotation;
    private float rotateSpeed;

    public override void EnterState(EnemyController enemy)
    {
        observeRotation = enemy.observeRotation;
        rotateSpeed = enemy.rotateSpeed;
    }

    public override void Update(EnemyController enemy)
    {
        enemy.transform.rotation = Quaternion.Euler(0f, observeRotation * Mathf.Sin(Time.time * rotateSpeed), 0f);
    }
}
