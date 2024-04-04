using System.Collections;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Teleporter destination;
    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            StartCoroutine(Teleport(player.gameObject));
        }
    }

    private IEnumerator Teleport(GameObject player)
    {
        yield return new WaitForSeconds(0.05f);
        player.transform.position = destination.gameObject.transform.position;
    }

}