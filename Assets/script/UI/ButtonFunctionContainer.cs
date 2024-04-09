using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctionContainer : MonoBehaviour
{
    [SerializeField] private GameObject PausePage;
    
    public void Resume()
    {
        PausePage.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Option()
    {
        PausePage.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Pause()
    {
        PausePage.SetActive(true);
        Time.timeScale = 0f;
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
