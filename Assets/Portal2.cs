using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal2 : MonoBehaviour
{
    public GameObject portal;
    public GameObject boss;
    EnemyStats enemyStats;

    private void Awake()
    {
        enemyStats = GetComponent<EnemyStats>();
    }
    public void portalappear()
    {
        if(enemyStats.currentHealth <= 0)
        {
            portal.SetActive(true);
        }
    }
}
