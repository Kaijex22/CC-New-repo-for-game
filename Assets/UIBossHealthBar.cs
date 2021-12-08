using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIBossHealthBar : MonoBehaviour
{
    public Text bossName;
    Slider slider;


    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        bossName = GetComponentInChildren<Text>();
    }

    private void Start()
    {
        slider.gameObject.SetActive(false);
    }

    public void SetBossNAME(string name)
    {
        bossName.text = name;
    }

    public void SetUiHealthBarToActive()
    {
        slider.gameObject.SetActive(true);
    }

    public void SetHealthBarToInactive()
    {
        slider.gameObject.SetActive(false);
    }

    public void SetBossMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public void SetBossCurrentHealth(int currentHealth)
    {
        slider.value = currentHealth;
    }
}
