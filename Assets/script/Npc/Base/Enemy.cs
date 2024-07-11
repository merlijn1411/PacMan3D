using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour, IThouchable, IEnemyMoveable
{
    public Rigidbody RB { get; set; }
    public bool IsFacingRight { get; set; } = true;

    public EnemyStateMachine StateMachine { get; set; }
    public EnemyWalkState WalkState { get; set; }
    public EnemyChaseState ChaseState { get; set; }

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
        RB.velocity = velocity;
        CheckForLeftOrRightFacing(velocity);
    }

    public void CheckForLeftOrRightFacing(Vector3 velocity)
    {
        if (IsFacingRight && velocity.x < 0f)
        {
            var rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }
        else if (!IsFacingRight && velocity.x > 0f)
        {
            var rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
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
