using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public GameObject wolf;


    

    Animator animator;

    private void Awake()
    {
        animator= GetComponentInChildren<Animator>();
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

        Debug.Log("hes taken damagae");

        animator.Play("Damage_01");

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            wolf.SetActive(false);
            
            
            //Handle player death
        }
    }

    public void Die()
    {
        Debug.Log("Enemy Died");
        
    }
}
