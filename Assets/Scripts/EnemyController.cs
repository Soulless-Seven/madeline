using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    [Header("Observing State:")]
    [Range(1.0f, 180.0f)] public float observeRotation;
    public float rotateSpeed;
    public float observeTime;

    [Header("Wander State:")]
    public List<Vector3> wanderCoordinates;

    private EnemyBaseState currentState;
    public EnemyBaseState CurrentState { get => currentState; }

    public readonly EnemyObservingState ObservingState = new EnemyObservingState();
    public readonly EnemyWanderState WanderState = new EnemyWanderState();


    void Start()
    {
        TransitionToState(ObservingState);
    }

    void FixedUpdate()
    {
        currentState.Update(this);
    }

    public void TransitionToState(EnemyBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);

        StopCoroutine("FindTargetsWithDelay");

        if (state == ObservingState || state == WanderState)
        {
            StartCoroutine("FindTargetWithDelay", 0.2f);
        }
    }

    private IEnumerator FindTargetWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTarget();
        }
    }

    /// <summary>
    /// Handles the Enemy's field of view and transitions to a Chase State if the player is located.
    /// </summary>
    private void FindVisibleTarget()
    {
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    visibleTargets.Add(target);
                    //TransitionToState();
                }
            }
        }
    }

    /// <summary>
    /// Used by EnemySightEditor. Draws the Enemy's field of view.
    /// </summary>
    /// <param name="angleInDegrees"></param>
    /// <param name="angleIsGlobal"></param>
    /// <returns></returns>
    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
