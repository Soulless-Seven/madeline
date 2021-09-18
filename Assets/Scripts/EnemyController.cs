using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
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
    }
}
