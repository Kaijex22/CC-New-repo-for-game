using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class EnemyStats : CharacterStats
{
    Animator animator;
    EnemyManager enemyManager;

    EnemyBossManager enemyBossManager;

    public UIEnemyHealthBar enemyHealthBar;
    InputHandler inputHandler;

    public bool isBoss;
    private float delayBeforeLoading = 6f;
    EnemyAnimatorManager enemyAnimator;

    

    private float timeElapsed;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        inputHandler = GetComponent<InputHandler>();
        enemyManager = GetComponent<EnemyManager>();
        maxHealth = SetMaxHealthFromHealthLevel();
        currentHealth = maxHealth;
        enemyBossManager = GetComponent<EnemyBossManager>();

        enemyAnimator = GetComponentInChildren<EnemyAnimatorManager>();
        if (isBoss == true)
        {
            isDead();
        }
    }

    void Start()
    {
        
        if (!isBoss)
        {
            maxHealth = SetMaxHealthFromHealthLevel();
        }
    }

    private int SetMaxHealthFromHealthLevel()
    {
        maxHealth = healthLevel * 10;
        return maxHealth;

    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;

        
        if (isBoss && enemyBossManager != null)
        {
            enemyBossManager.UpdateBossHealth(currentHealth);
        }

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
    public void isDead()
    {

        if (currentHealth == 0)
        {
            FindObjectOfType<AudioManager>().Play("Boss Death");
            

            timeElapsed += Time.deltaTime;

            if (timeElapsed > delayBeforeLoading)
            {
                SceneManager.LoadScene("Credits");
            }

        }
    }

}
