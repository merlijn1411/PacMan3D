using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class ButtonFunctionContainer : MonoBehaviour
{
    [SerializeField] private GameObject pausePage;
    [SerializeField] private GameObject nonDiegetic;

    [SerializeField] private PauseController pauseController;
    
    public void Resume()
    {
        pausePage.SetActive(false);
        nonDiegetic.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        pauseController.isGamePaused = false;
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pausePage.SetActive(true);
        nonDiegetic.SetActive(false);
        Time.timeScale = 0f;
        pauseController.isGamePaused = true;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("Loading Game...");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Loading menu...");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
