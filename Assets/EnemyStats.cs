using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyStats : CharacterStats
{
    Animator animator;
    EnemyManager enemyManager;

    public UIEnemyHealthBar enemyHealthBar;
    InputHandler inputHandler;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        inputHandler = GetComponent<InputHandler>();
        enemyManager = GetComponent<EnemyManager>();
    }

    void Start()
    {
        maxHealth = SetMaxHealthFromHealthLevel();
        currentHealth = maxHealth;
    }

    private int SetMaxHealthFromHealthLevel()
    {
        maxHealth = healthLevel * 10;
        return maxHealth;

    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;

        FindObjectOfType<AudioManager>().Play("SwordSwing");

        animator.Play("Damage_01");

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            
            animator.Play("Dead_01");
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            enemyManager.navmeshAgent.enabled = false;
            
            Destroy(gameObject, 4);
            




        }
    }
    
}
