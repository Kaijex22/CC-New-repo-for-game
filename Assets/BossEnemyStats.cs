using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyStats : CharacterStats
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
        maxHealth = SetMaxHealthFromHealthLevel();
        currentHealth = maxHealth;
    }

    void Start()
    {
        maxHealth = SetMaxHealthFromHealthLevel();

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

            animator.Play("Mutant Dying 1");
            FindObjectOfType<AudioManager>().Play("Boss Death");
            enemyManager.navmeshAgent.enabled = false;

            Destroy(gameObject, 4);





        }
    }

}
