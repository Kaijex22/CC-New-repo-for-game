using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int healthLevel = 10;
    public int maxHealth;
    public int currentHealth;

    public int maxStamina;
    public int currentStanima;
    public int staminaLevel = 10;

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
            //Handle player death
        }
    }
    public void TakeStaminaDamage(int damage)
    {
        currentStanima = currentStanima - damage;
        staminaBar.SetCurrentStamina(currentStanima);
    }
  
}