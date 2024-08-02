using System.Numerics;
using Vector3 = UnityEngine.Vector3;

public interface IChaseable
{
    void ChaseTarget(Vector3 velocity);
}
