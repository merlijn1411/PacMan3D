using System.Collections;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Vector3[] waypoints;

    private static Waypoint main;

    private void Awake()
    {
        main = this;    
    }

    public Vector3 GetWaypointPosition(int index)
    {
        if (index >= 0 && index < waypoints.Length)
        {
            return transform.position + waypoints[index];
        }
        else
        {
            Debug.LogWarning("no waypoint detected");
            return Vector3.zero;
        }
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < waypoints.Length; i++)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(transform.position + waypoints[i], 0.5f);

            if (i < waypoints.Length - 1)
            {
                Gizmos.color = Color.gray;
                Gizmos.DrawLine(transform.position + waypoints[i], transform.position + waypoints[i + 1]);
            }
        }
    }
}
