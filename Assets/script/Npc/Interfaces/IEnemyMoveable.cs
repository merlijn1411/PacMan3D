using UnityEngine;

public interface IEnemyMoveable 
{
   Rigidbody RB { get; set;}
   void EnemyWandering(Vector3 velocity, float distance);

   void InstantlyTurn(Vector3 destination);
}
