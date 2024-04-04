using UnityEngine;

public class IsDeath : MonoBehaviour
{
    private static bool GameisPaused = false;
    [SerializeField] private GameObject EndScreen;

    private void Start()
    {
        EndScreen.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
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
