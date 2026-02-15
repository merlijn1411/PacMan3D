using UnityEngine;

public class EnemyCollideCheck : MonoBehaviour
{
    private string _tag = "Player";
    private Enemy _enemy;
    
    private void Awake()
    {
        _enemy = GetComponentInParent<Enemy>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag(_tag))
        {
            _enemy.SetCollidingStatus(true);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag(_tag))
        {
            _enemy.SetCollidingStatus(false);
        }
    }
}
