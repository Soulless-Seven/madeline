using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDistraction : MonoBehaviour
{
    public GameObject monster;

    private EnemyController enemyController;

    void Start()
    {
        enemyController = monster.GetComponent<EnemyController>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // not best practice but we got a prototype to finish!
        if (collision.gameObject.name.Contains("Distraction"))
        {
            enemyController.positionToInvestigate = transform.position;
            enemyController.TransitionToState(enemyController.InvestigateState);
        }
    }
}
