using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private int currentPatrolIndex = 0;
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Start patrolling towards the first point
        SetDestination(patrolPoints[currentPatrolIndex].position);
    }

    private void Update()
    {
        // Check if the enemy has reached the current patrol point
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.1f)
        {
            // Move to the next patrol point
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            SetDestination(patrolPoints[currentPatrolIndex].position);
        }
    }

    private void SetDestination(Vector3 targetPosition)
    {
        // Set the NavMeshAgent's destination and start moving
        navMeshAgent.SetDestination(targetPosition);
    }
}
