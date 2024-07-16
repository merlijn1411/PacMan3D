using UnityEngine;

public class Enemy : MonoBehaviour, IChaseable, IEnemyMoveable, ITriggerCheckable
{
    public Rigidbody RB { get; set; }
    public bool IsFacingRight { get; set; } = true;

    public EnemyStateMachine StateMachine { get; set; }
    public EnemyWalkState WalkState { get; set; }
    public EnemyChaseState ChaseState { get; set; }

    public float MovememtSpeed = 1f;
    public float RandomeMovementRange = 5f;
    
    public bool IsChasing { get; set; }
    public bool IsColliding { get; set; }
    private void Awake()
    {
        StateMachine = new EnemyStateMachine();
        
        WalkState = new EnemyWalkState(this, StateMachine);
        ChaseState = new EnemyChaseState(this, StateMachine);
        
    }

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        
        StateMachine.Initialize(WalkState);
    }

    private void Update()
    {
        StateMachine.currentEnemyState.FrameUpdate();
        
        Debug.Log(IsChasing);
    }

    private void FixedUpdate()
    {
        StateMachine.currentEnemyState.PhysicUpdate();
    }

    public void Collide()
    {
        
    }

    public void Ishasing()
    {
        
    }
    
    public void MoveEnemy(Vector3 velocity, float distance)
    {
        RB.velocity = velocity;
        WalkState.GetRandomPointOnNavMesh(velocity, distance);
    }
    public void MoveEnemy(Vector3 velocity)
    {
        RB.velocity = velocity;
    }
    
    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        StateMachine.currentEnemyState.AnimationTriggerEvent(triggerType);
    }
    
    public enum AnimationTriggerType
    {
        EnemyWalking,
        EnemyFleeing,
        EnemyChasing
    }
    
    public void SetInRangeStatus(bool isChasing)
    {
        IsChasing = isChasing;
    }

    public void SetCollidingStatus(bool isColliding)
    {
        IsColliding = isColliding;
    }

    
}
