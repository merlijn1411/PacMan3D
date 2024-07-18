using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class KeepScore : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreField;

    public UnityEvent hasAllPoints;

    private void Update()
    {
        GameObject[] points = GameObject.FindGameObjectsWithTag("Points");
        scoreField.text = points.Length.ToString();
        PointsLeft(points);
    }

    private void PointsLeft(GameObject[] points)
    {
        if (points.Length == 0)
        {
            hasAllPoints.Invoke();
        }
    }
}
