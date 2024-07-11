using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour, IThouchable, IEnemyMoveable
{
    public Rigidbody RB { get; set; }
    public bool IsFacingRight { get; set; } = true;

    public EnemyStateMachine StateMachine { get; set; }
    public EnemyWalkState WalkState { get; set; }
    public EnemyChaseState ChaseState { get; set; }

    public float RandomMovememtSpeed = 1f;
    public float RandomMovementRange = 5f;

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

    public void Touch()
    {
        
    }

    public void GetsEaten()
    {
        
    }
    
    public void MoveEnemy(Vector3 velocity)
    {
        velocity.y = 1.37f;
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
        EnemyFleeing
    }
}
