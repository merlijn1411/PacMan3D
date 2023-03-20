using UnityEngine;
using UnityEngine.Events;

public class IsThouched : MonoBehaviour
{
    public UnityEvent hasNoLves;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {
            hasNoLves.Invoke();
        }
    }
}
