using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeepScore : MonoBehaviour
{
    //deze moet in de canvas: score 
    private TMP_Text scoreField;
    private int score = 0;

    void Start()
    {
        scoreField = GetComponent<TMP_Text>();
        score = 0;  
        scoreField.text = "" + score;
        
    }

    void Update()
    {
        GameObject[] points = 
            GameObject.FindGameObjectsWithTag("Points");
        scoreField.text = points.Length.ToString();
        if (points.Length > 0)
        {
            
        }
    }

    public void AddScore(int scoreScript)
    {
        score += scoreScript;
        scoreField.text = "" + score;
        
    }
}
