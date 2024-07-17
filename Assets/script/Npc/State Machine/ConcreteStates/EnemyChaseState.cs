using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseState : EnemyState
{
    private NavMeshAgent _navMeshAgent;
    
    private Transform _playerTransform;
    public EnemyChaseState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        
    }

    public override void EnterState()
    {
        base.EnterState();
        _navMeshAgent = enemy.GetComponent<NavMeshAgent>();
        _navMeshAgent.ResetPath();
        
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        _navMeshAgent.SetDestination(_playerTransform.position);
        Debug.Log(_playerTransform.position);
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
    
    
    
}