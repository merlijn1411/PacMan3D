using UnityEngine;
using UnityEngine.AI;

public class npcPath : MonoBehaviour
{
    [SerializeField] private NavMeshAgent Enemy;
    [SerializeField] private Transform target;
    [SerializeField] private float followRadius ;
    [SerializeField] private float wanderRadius ;
    [SerializeField] private float wanderTimer ;

   [SerializeField] private Vector3 startingPosition;
   [SerializeField] private float timer;
   
    void Start()
    {
        startingPosition = transform.position;
        timer = wanderTimer;
        Enemy.speed = 10f;
    }
    
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

            if (Enemy.pathStatus == NavMeshPathStatus.PathInvalid || Enemy.pathStatus == NavMeshPathStatus.PathPartial)
            {
                Vector3 newPos = GetRandomPointOnNavMesh(startingPosition, wanderRadius);
                Enemy.SetDestination(newPos);
            }
        }
        
        if (Enemy.remainingDistance <= Enemy.stoppingDistance && !Enemy.pathPending)
        {
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