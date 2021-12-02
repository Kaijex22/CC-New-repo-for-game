using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HealthBar : MonoBehaviour
{
    public Slider slider;
    InputHandler inputHandler;
    private void Awake()
    {
        inputHandler = GetComponent<InputHandler>();
    }

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public void SetCurrentHealth(int currentHealth)
    {
        slider.value = currentHealth;
    }

    public void Death(int currentHealth)
    {
        if (currentHealth == 0)
        {
            SceneManager.LoadScene("SampleScene");
        }

    }

    public void Potion(int currentHealth)
    {
        currentHealth = currentHealth + 20;
        
        inputHandler.isInteracting = true;
    }
}
