using UnityEngine;
using UnityEngine.Serialization;


public class PauseGame : MonoBehaviour
{
    private bool _isGamePaused = false;

    [SerializeField] private ButtonFunctionContainer buttonFunctionContainer;
    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        buttonFunctionContainer.Resume();
    }

    private void Update()
    {
        PauseController();
    }

    private void PauseController()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            PauseChecker();
    }

    private void PauseChecker()
    {
        if (_isGamePaused) 
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            buttonFunctionContainer.Resume();
            _isGamePaused = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            buttonFunctionContainer.Pause();
            _isGamePaused = true;
        }
    }
}
