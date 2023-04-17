using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IsDeath : MonoBehaviour
{
    public static bool GameisPaused = false;
    public GameObject EndScreen;

    void Start()
    {
        EndScreen.SetActive(false);
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ghost")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            gameOver();
        }
    }

    void gameOver()
    {
        EndScreen.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }
}
