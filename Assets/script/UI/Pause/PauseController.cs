using UnityEngine;
using UnityEngine.Serialization;


public class PauseController : MonoBehaviour
{
    public bool isGamePaused = false;

    [SerializeField] private ButtonFunctionContainer buttonFunctionContainer;
    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        buttonFunctionContainer.Resume();
    }

    private void Update()
    {
        PauseControl();
    }

    private void PauseControl()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            PauseChecker();
    }

    private void PauseChecker()
    {
        isGamePaused = !isGamePaused;
        if (!isGamePaused) 
            buttonFunctionContainer.Resume();
        else if (isGamePaused)
            buttonFunctionContainer.Pause();
        
    }
}
