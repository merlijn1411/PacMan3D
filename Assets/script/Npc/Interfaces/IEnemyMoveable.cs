using UnityEngine;

public interface IEnemyMoveable 
{
   Rigidbody RB { get; set;}
   void EnemyPatrolling(Vector3 velocity, float distance);
}
