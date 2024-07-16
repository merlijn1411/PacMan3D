using UnityEngine;

public class EnemyChaseState : EnemyState
{
    
    public EnemyChaseState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        
    }

    public override void EnterState()
    {
        base.EnterState();
        
        Debug.Log("Hello");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        enemy.MoveEnemy(Vector3 .zero);
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}