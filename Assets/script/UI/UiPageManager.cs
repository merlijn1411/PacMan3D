using UnityEngine;
using UnityEngine.SceneManagement;
public class UiPageManager : MonoBehaviour
{
    public GameObject[] pages; 
    private int _currentPageIndex = 1; 

    void Start()
    {
        for (int i = 1; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
        }
    }

    public void NextPage()
    {
        pages[_currentPageIndex].SetActive(false);

        _currentPageIndex = (_currentPageIndex + 1) % pages.Length;

        pages[_currentPageIndex].SetActive(true);
    }

    public void PreviousPage()
    {
       pages[_currentPageIndex].SetActive(false);

       _currentPageIndex = (_currentPageIndex - 1 + pages.Length) % pages.Length;

       pages[_currentPageIndex].SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        print("close");
        Application.Quit();
    }
}
