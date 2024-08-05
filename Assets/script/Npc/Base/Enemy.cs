using UnityEngine;

public class Enemy : MonoBehaviour, IChaseable, IEnemyMoveable, ITriggerCheckable
{
    public Rigidbody RB { get; set; }
    public EnemyStateMachine StateMachine { get; set; }
    public EnemyWanderingState WanderingState { get; set; }
    public EnemyPatrolState PatrolState { get; set; }
    public EnemyChaseState ChaseState { get; set; }

    public float MovememtSpeed = 1f;
    public float RandomeMovementRange = 5f;
    public Waypoint GhostWaypoint;
    
    public bool IsChasing { get; set; }
    public bool IsColliding { get; set; }
    private void Awake()
    {
        StateMachine = new EnemyStateMachine();
        
        WanderingState = new EnemyWanderingState(this, StateMachine);
        ChaseState = new EnemyChaseState(this, StateMachine);
        PatrolState = new EnemyPatrolState(this, StateMachine);
    }

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        
        StateMachine.Initialize(PatrolState);
    }

    private void Update()
    {
        StateMachine.currentEnemyState.FrameUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.currentEnemyState.PhysicUpdate();
    }

    public void Collide()
    {
        
    }

    public void ChaseTarget(Vector3 velocity)
    {
        RB.velocity = velocity;
    }
    
    public void EnemyWandering(Vector3 velocity, float distance)
    {
        RB.velocity = velocity;
        WanderingState.GetRandomPointForNavMesh(velocity, distance);
    }

    public void InstantlyTurn(Vector3 destination) {
        if ((destination - transform.position).magnitude < 0.1f) return; 
    
        var direction = (destination - transform.position).normalized;
        var  qDir= Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, qDir, Time.deltaTime * 20f);
    }
    
    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        StateMachine.currentEnemyState.AnimationTriggerEvent(triggerType);
    }
    
    public enum AnimationTriggerType
    {
        EnemyWalking,
        EnemyFleeing,
        EnemyScared
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
