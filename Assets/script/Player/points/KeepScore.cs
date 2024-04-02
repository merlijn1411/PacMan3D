using TMPro;
using UnityEngine;

public class KeepScore : MonoBehaviour
{
    private TMP_Text scoreField;
    private int score = 0;

    public GameObject WinScreen;

    void Start()
    {
        scoreField = GetComponent<TMP_Text>();
        score = 0;  
        scoreField.text = "" + score;
        
    }

    void Update()
    {
        GameObject[] points = GameObject.FindGameObjectsWithTag("Points");
        scoreField.text = points.Length.ToString();
        if (points.Length == 0)
        {
            YouWin();
        }
    }

    void YouWin()
    {
        Time.timeScale = 0f;
        WinScreen.SetActive(true);
    }

    public void AddScore(int scoreScript)
    {
        score += scoreScript;
        scoreField.text = "" + score;
        
    }
}
