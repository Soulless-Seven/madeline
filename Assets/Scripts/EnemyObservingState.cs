using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObservingState : EnemyBaseState
{
    private int observeDegrees;

    public override void EnterState(EnemyController enemy)
    {
        observeDegrees = enemy.observeDegrees;
    }

    public override void Update(EnemyController enemy)
    {
        Vector3 to = new Vector3(0, observeDegrees, 0);
        enemy.transform.eulerAngles = Vector3.Lerp(enemy.transform.rotation.eulerAngles, to, Time.deltaTime);
    }
}
