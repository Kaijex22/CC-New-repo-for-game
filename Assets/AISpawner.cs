using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    EnemyStats enemyStats;

    public GameObject ai1;
    public GameObject ai2;

    private void Awake()
    {
        enemyStats = GetComponent<EnemyStats>();
    }

    public void SpawnUnits()
    {
        if(enemyStats.currentHealth > 500)
        {
            ai1.gameObject.SetActive(true);
            ai2.gameObject.SetActive(true);
        }
    }
}
