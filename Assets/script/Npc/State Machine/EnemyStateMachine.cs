using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine
{
    public EnemyState currentEnemyState { get; set; }

    public void Initialize(EnemyState startingState)
    {
        currentEnemyState = startingState;
        currentEnemyState.EnterState();
    }

    public void ChangeState(EnemyState newtState)
    {
        currentEnemyState.EnterState();
        currentEnemyState = newtState;
        currentEnemyState.EnterState();
    }
}
