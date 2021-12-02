using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemyHealthBar : MonoBehaviour
{
    Slider slider;
    float timeUntilBarIsHidden = 3;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        timeUntilBarIsHidden = 3;
        
    }

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        

    }
        private void Update()
    {
        
        if(slider.value <= 0)
        {
            Destroy(slider.gameObject);
        }
    }
}
