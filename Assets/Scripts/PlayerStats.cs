using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
    

    public HealthBar healthBar;
    public StaminaBar staminaBar;
    AnimatorHandler animatorHandler;

    
    

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

        animatorHandler.PlayTargetAnimation("Damage_01", true);

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            animatorHandler.PlayTargetAnimation("Dead_01", true);
            
            SceneManager.LoadScene("SampleScene");
            
        }
    }
    public void TakeStaminaDamage(int damage)
    {
        currentStanima = currentStanima - damage;
        staminaBar.SetCurrentStamina(currentStanima);
    }

  


}
