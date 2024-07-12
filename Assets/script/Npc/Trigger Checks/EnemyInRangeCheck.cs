using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInRangeCheck : MonoBehaviour
{
    public GameObject playerTarget { get; set; }
    private Enemy _enemy;

    private void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player");

        _enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerTarget)
        {
            _enemy.SetInRangeStatus(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerTarget)
        {
            _enemy.SetInRangeStatus(false);
        }
    }
}
