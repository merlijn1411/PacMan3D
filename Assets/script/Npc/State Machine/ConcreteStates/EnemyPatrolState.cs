using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolState : EnemyState
{
    private NavMeshAgent _navMeshAgent;
    public Vector3 CurrentPointPosition { get; private set; }
    private int _currentWaypointIndex;
    
    public EnemyPatrolState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        _navMeshAgent = enemy.GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.speed = enemy.MovememtSpeed;
        
    }

    public override void ExitState()
    {
        base.ExitState();   
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        CurrentPointPosition = enemy.GhostWaypoint.GetWaypointPosition(_currentWaypointIndex); 
        EnemyMoveAndRotateToPoint();
        if (CurrentPointPositionReached())
        {
            UpdateCurrentPointIndex();
        }
    }

    private void EnemyMoveAndRotateToPoint()
    {
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, CurrentPointPosition, _navMeshAgent.speed * Time.deltaTime);
        InstantlyTurn(CurrentPointPosition);
    }
    
    private void InstantlyTurn(Vector3 destination) {
        //When on target -> dont rotate!
        if ((destination - enemy.transform.position).magnitude < 0.1f) return; 
    
        var direction = (destination - enemy.transform.position).normalized;
        var  qDir= Quaternion.LookRotation(direction);
        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, qDir, Time.deltaTime * 20f);
    }
    
    private bool CurrentPointPositionReached()
    {
        var distanceToNextPointPosition = (enemy.transform.position - CurrentPointPosition).magnitude;
        Mathf.Abs(distanceToNextPointPosition);
        if (distanceToNextPointPosition < 1f)
        {
            CurrentPointPosition = enemy.transform.position;
            return true;
        }
        return false;
    }

    private void UpdateCurrentPointIndex()
    {
        var lastWaypointIndex = enemy.GhostWaypoint.waypoints.Length - 1;
        if(_currentWaypointIndex == lastWaypointIndex)
        {
            _currentWaypointIndex = 0;
        }
        else
        {
            _currentWaypointIndex++;
            CurrentPointPosition = enemy.GhostWaypoint.waypoints[_currentWaypointIndex];
        }
    }
    
    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
    
    
}

