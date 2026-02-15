using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject miniMapSize;

    private void Update()
    {
        MapSizeController();
    }

    private void MapSizeController()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            miniMapSize.SetActive(!miniMapSize.activeSelf);
        }
    }

    private void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}
