using UnityEngine;


public class Enemy : MonoBehaviour, IChaseable, IEnemyMoveable, ITriggerCheckable
{
    public Rigidbody RB { get; set; }
    public bool IsFacingRight { get; set; } = true;

    public EnemyStateMachine StateMachine { get; set; }
    public EnemyWalkState WalkState { get; set; }
    public EnemyChaseState ChaseState { get; set; }

    public float MovememtSpeed = 1f;
    public float RandomMovementRange = 5f;
    
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
    
    public void MoveEnemy(Vector3 velocity)
    {
        RB.velocity = velocity;
        ModelFaceRotator(velocity);
    }

    public void ModelFaceRotator(Vector3 velocity)
    {
        if (velocity != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(velocity.x, 0f, velocity.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
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
