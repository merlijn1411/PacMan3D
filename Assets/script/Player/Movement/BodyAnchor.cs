using UnityEngine;

public class BodyAnchor : MonoBehaviour
{
    private Transform _pacmanTransform;
    [SerializeField] private Transform playerCamTransform;
    private void Start()
    {
        _pacmanTransform = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        _pacmanTransform.position = playerCamTransform.position;
        _pacmanTransform.rotation = playerCamTransform.rotation;
    }
}
