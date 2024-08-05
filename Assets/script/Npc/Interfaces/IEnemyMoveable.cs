using UnityEngine;

public interface IEnemyMoveable 
{
   Rigidbody RB { get; set;}
   void EnemyWandering(Vector3 velocity, float distance);

   void EnemyPatrolling(Vector3 velocity);
}
