using UnityEngine;
using UnityEngine.AI;

public class EnemyWalkState : EnemyState
{
    private NavMeshAgent _navMeshAgent;
    private Vector3 _currentPos;
    private Vector3 _targetPos;
    private Vector3 _direction;
    
    public EnemyWalkState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
       
    }

    public override void EnterState()
    {
        base.EnterState();
        _navMeshAgent = enemy.GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = enemy.MovememtSpeed;

        _targetPos = GetRandomPointOnNavMesh(enemy.transform.position, enemy.RandomMovementRange);
        _navMeshAgent.SetDestination(_targetPos);
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if (enemy.IsChasing)
        {
            enemy.StateMachine.ChangeState(enemy.ChaseState);
        }

        if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            _targetPos = GetRandomPointOnNavMesh(enemy.transform.position, enemy.RandomMovementRange);
            _navMeshAgent.SetDestination(_targetPos);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    private Vector3 GetRandomPointOnNavMesh(Vector3 center, float distance)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * distance;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, distance, NavMesh.AllAreas))
        {
            return hit.position;
        }
        return center;
    }
}
