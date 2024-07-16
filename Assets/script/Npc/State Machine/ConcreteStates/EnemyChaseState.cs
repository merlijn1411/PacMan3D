using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseState : EnemyState
{
    private NavMeshAgent _navMeshAgent;
    
    private Transform _playerTransform;
    public EnemyChaseState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void EnterState()
    {
        base.EnterState();
        _navMeshAgent = enemy.GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = enemy.MovememtSpeed;
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        var moveDirection = (_playerTransform.position - enemy.transform.position).normalized;
        
        enemy.MoveEnemy(enemy.MovememtSpeed * moveDirection);
        
        
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}