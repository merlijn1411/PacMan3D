using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MiniMap : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private GameObject MiniMapSize;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            MiniMapSize.SetActive(true);
        }
        if(Input.GetKeyUp(KeyCode.Tab)) 
        {
            MiniMapSize.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        Vector3 newPosition = Player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}
