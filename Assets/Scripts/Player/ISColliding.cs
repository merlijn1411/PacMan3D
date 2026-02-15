using UnityEngine;
using UnityEngine.Events;

public class ISColliding : MonoBehaviour
{
    public UnityEvent hasNoLves;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hasNoLves.Invoke();
        }
    }
}
