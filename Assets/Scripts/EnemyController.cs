using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Observing State:")]
    [Range(1, 180)] public int observeDegrees;

    private EnemyBaseState currentState;
    public EnemyBaseState CurrentState { get => currentState; }

    public readonly EnemyObservingState ObservingState = new EnemyObservingState(); 

    // Start is called before the first frame update
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
