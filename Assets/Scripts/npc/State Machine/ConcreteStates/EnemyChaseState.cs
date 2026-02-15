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
        _navMeshAgent.updateRotation = true;
        
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

        if (!enemy.IsChasing)
        {
            enemyStateMachine.ChangeState(enemy.WanderingState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
    
    
    
}