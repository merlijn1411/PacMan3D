using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Getpickup : MonoBehaviour
{
    //deze code is voor de coin/point
    GameObject obj;
    private KeepScore scoreScript;
    
    void Start()
    {
        scoreScript = FindObjectOfType<KeepScore>();
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.tag == "Player")
        {
            Destroy(gameObject, 0f);
            
            //scoreScript.AddScore(1);
        }
    }


}

