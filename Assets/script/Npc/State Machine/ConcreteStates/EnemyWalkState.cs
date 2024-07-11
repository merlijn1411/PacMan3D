using UnityEngine;

public class EnemyWalkState : EnemyState
{
    private Vector3 _targetPos;
    private Vector3 _direction;
    
    public EnemyWalkState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        
    }

    public override void EnterState()
    {
        base.EnterState();

        _targetPos = GetRandomPointInCircle();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        _direction = (_targetPos - enemy.transform.position).normalized;
        
        enemy.MoveEnemy(_direction * enemy.RandomMovememtSpeed);

        if ((enemy.transform.position - _targetPos).sqrMagnitude < 0.01f)
        {
            _targetPos = GetRandomPointInCircle();
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    private Vector3 GetRandomPointInCircle()
    {
        var randomPoint2D = UnityEngine.Random.insideUnitCircle * enemy.RandomMovementRange;
        return new Vector3(randomPoint2D.x, enemy.transform.position.y, randomPoint2D.y);
    }
}
