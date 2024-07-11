using UnityEngine;

public interface IEnemyMoveable 
{
   Rigidbody RB { get; set;}
   bool IsFacingRight { get; set; }

   void MoveEnemy(Vector3 velocity);
   void CheckForLeftOrRightFacing(Vector3 velocity);
}
