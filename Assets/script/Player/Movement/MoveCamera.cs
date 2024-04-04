using UnityEngine;

public class MoveCamera: MonoBehaviour
{
    [SerializeField] private Transform cameraPosition;

    public void Update()
    {
        transform.position = cameraPosition.position;
    }

}
