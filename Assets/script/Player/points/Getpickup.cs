using UnityEngine;

public class Getpickup : MonoBehaviour
{
    [SerializeField] private AudioClip coin;
    [SerializeField] private AudioSource aScorce;
    [SerializeField] private GameObject obj;
    private KeepScore scoreScript;
    void Start()
    {
        aScorce = GetComponent<AudioSource>(); 
        scoreScript = FindAnyObjectByType<KeepScore>();
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("+1");
        if (other.tag == "Player")
        {
            Destroy(gameObject, 0.5f);
            aScorce.clip = coin;
            scoreScript.AddScore(5);
            aScorce.Play();
        }
    }


}

