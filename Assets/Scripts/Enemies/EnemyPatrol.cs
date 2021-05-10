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
        StartCoroutine(Patrol());   //We use the Unity Engine AI to make the NavMesh recognize a path.
    }

    private IEnumerator Patrol()
    {
        while(true)     //We use this so that it loops constantly between the waypoints
        {
            for(int i = 0; i < waypoints.Length; i++)
            {
                myAgent.SetDestination(waypoints[i].position);      //We set up the next point in the path
                while(myAgent.pathPending)
                {
                    yield return null;      //The AI did not get to the point, it's still traveling
                }

                while(myAgent.remainingDistance > myAgent.stoppingDistance)
                {
                    yield return null;      //The AI reached the waypoint, so we start the whole process again
                }
            }
        }
    }
}
