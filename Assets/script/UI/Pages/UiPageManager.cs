using UnityEngine;
using UnityEngine.SceneManagement;

public class UiPageManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _pages; 
    private int _currentPageIndex = 1; 

    private void Start()
    {
        for (int i = 1; i < _pages.Length; i++)
        {
            _pages[i].SetActive(false);
        }
    }

    public void NextPage()
    {
        _pages[_currentPageIndex].SetActive(false);

        _currentPageIndex = (_currentPageIndex + 1) % _pages.Length;

        _pages[_currentPageIndex].SetActive(true);
    }

    public void PreviousPage()
    {
       _pages[_currentPageIndex].SetActive(false);

       _currentPageIndex = (_currentPageIndex - 1 + _pages.Length) % _pages.Length;

       _pages[_currentPageIndex].SetActive(true);
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
