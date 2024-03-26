using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Getpickup : MonoBehaviour
{
    //deze code is voor de coin
    public AudioClip coin;
    AudioSource aScorce;
    GameObject obj;
    private KeepScore scoreScript;
    void Start()
    {
        aScorce = GetComponent<AudioSource>(); // get component once @ Start more efficient.
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

