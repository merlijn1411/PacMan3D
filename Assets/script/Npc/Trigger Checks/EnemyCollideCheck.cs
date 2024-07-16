using UnityEngine;

public class EnemyCollideCheck : MonoBehaviour
{
    public GameObject PlayerTarget { get; set; }
    private Enemy _enemy;
    private void Awake()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");

        _enemy = GetComponentInParent<Enemy>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == PlayerTarget)
        {
            _enemy.SetCollidingStatus(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == PlayerTarget)
        {
            _enemy.SetCollidingStatus(false);
        }
    }
}
