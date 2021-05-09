using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent myAgent;

    [SerializeField]
    Transform[] waypoints;

    void Start()
    {
        StartCoroutine(Patrol());
    }

    private IEnumerator Patrol()
    {
        while(true)
        {
            for(int i = 0; i < waypoints.Length; i++)
          {
            myAgent.SetDestination(waypoints[i].position);

            while(myAgent.pathPending)
            {
                yield return null;
            }

            while(myAgent.remainingDistance > myAgent.stoppingDistance)
            {
                yield return null;
            }
          }
        }
    }
}
