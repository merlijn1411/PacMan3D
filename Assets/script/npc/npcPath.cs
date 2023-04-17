using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npcPath : MonoBehaviour
{
    public NavMeshAgent Enemy;
    public Transform target;
    public float followRadius = 5f;
    public float wanderRadius = 10f;
    public float wanderTimer = 5f;

    private Vector3 startingPosition;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        timer = wanderTimer;
        Enemy.speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget <= followRadius)
        {
            Enemy.destination = target.position;
            timer = wanderTimer;
        }
        else
        {
            timer += Time.deltaTime;

            if (timer >= wanderTimer)
            {
                Vector3 newPos = GetRandomPointOnNavMesh(startingPosition, wanderRadius);
                Enemy.SetDestination(newPos);
                timer = 0;
            }

            // Check if the current destination is invalid
            if (Enemy.pathStatus == NavMeshPathStatus.PathInvalid || Enemy.pathStatus == NavMeshPathStatus.PathPartial)
            {
                // Reset the destination to a random point on the NavMesh
                Vector3 newPos = GetRandomPointOnNavMesh(startingPosition, wanderRadius);
                Enemy.SetDestination(newPos);
            }
        }

        // Check if the agent has stopped moving
        if (Enemy.remainingDistance <= Enemy.stoppingDistance && !Enemy.pathPending)
        {
            // Reset the destination to a random point on the NavMesh
            Vector3 newPos = GetRandomPointOnNavMesh(startingPosition, wanderRadius);
            Enemy.SetDestination(newPos);
        }
    }

    private Vector3 GetRandomPointOnNavMesh(Vector3 center, float distance)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * distance;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomPoint, out hit, distance, NavMesh.AllAreas);
        return hit.position;
    }
}   