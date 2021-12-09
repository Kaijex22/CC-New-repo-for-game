using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
    

    public HealthBar healthBar;
    public StaminaBar staminaBar;
    AnimatorHandler animatorHandler;


    public bool isTutorial;
    public bool isBossLevel;
    public bool isLevel1;
    public bool isLava;


    int potion = 10;
    

    private void Awake()
    {
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
        staminaBar = FindObjectOfType<StaminaBar>();
    }
    void Start()
    {
        maxHealth = SetMaxHealthFromHealthLevel();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        maxStamina = SetMaxStaminaFromStaminaLevel();
        currentStanima = maxStamina;
        
    }

    private int SetMaxHealthFromHealthLevel()
    {
        maxHealth = healthLevel * 10;
        return maxHealth;
    }
    private int SetMaxStaminaFromStaminaLevel()
    {
        maxStamina = staminaLevel * 10;
        return maxStamina;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;

        healthBar.SetCurrentHealth(currentHealth);
        FindObjectOfType<AudioManager>().Play("SwordSwing");

        animatorHandler.PlayTargetAnimation("Damage_01", true);

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            animatorHandler.PlayTargetAnimation("Dead_01", true);
            
            if(isBossLevel == true)
            {
                FindObjectOfType<AudioManager>().Play("PlayerDeath");

                SceneManager.LoadScene("BossFight");
            }
            else if (isTutorial == true)
            {
                SceneManager.LoadScene("SampleScene");
            }
            else if (isLevel1 == true)
            {
                SceneManager.LoadScene("Level 1");
            }
            else if (isLava == true)
            {
                SceneManager.LoadScene("Final Lava level");
            }
            
        }
    }
    public void TakeStaminaDamage(int damage)
    {
        currentStanima = currentStanima - damage;
        staminaBar.SetCurrentStamina(currentStanima);
    }

    public void Potion(int currentHealth)
    {
        currentHealth = currentHealth + potion;

        healthBar.SetCurrentHealth(currentHealth);
    }

  


}
