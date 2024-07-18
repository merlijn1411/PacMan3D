using UnityEngine;

public class PickUpPoint : MonoBehaviour
{
    [SerializeField] private AudioClip coin;
    [SerializeField] private AudioSource pickUpSound;
    [SerializeField] private GameObject obj;
    void Start()
    {
        pickUpSound = GetComponent<AudioSource>(); 
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject, 0.5f);
            pickUpSound.clip = coin;
            pickUpSound.Play();
        }
    }
}

