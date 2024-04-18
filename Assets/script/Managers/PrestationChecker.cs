using TMPro;
using UnityEngine;

public class PrestationChecker : MonoBehaviour
{
    [SerializeField] private GameObject prestationScreen;
    [SerializeField] private TMP_Text prestationText;

    public void Win()
    {
        Time.timeScale = 0f;
        prestationScreen.SetActive(true);
        prestationText.text = $"You win";
        CursonSwitch();
    }

    public void Loose()
    {
        Time.timeScale = 0f;
        prestationScreen.SetActive(true);
        prestationText.text = $"You Loose";
        CursonSwitch();
    }

    private void CursonSwitch()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
