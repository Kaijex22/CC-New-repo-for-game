using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossManager : MonoBehaviour
{
    public string bossName;
    UIBossHealthBar bossHealthBar;
    EnemyStats enemyStats;
    private void Awake()
    {
        bossHealthBar = FindObjectOfType<UIBossHealthBar>();
        enemyStats = GetComponent<EnemyStats>();
    }

    private void Start()
    {
        bossHealthBar.SetBossNAME(bossName);
        bossHealthBar.SetBossMaxHealth(enemyStats.maxHealth);
    }

    public void UpdateBossHealth(int currentHealth)
    {
        bossHealthBar.SetBossCurrentHealth(currentHealth);
    }
    //Handle switching phase
    //handle switching attack phase
}
