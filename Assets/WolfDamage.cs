using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfDamage : MonoBehaviour
{
    PlayerStats playerStats;
    public GameObject mouth;
    public GameObject playerModel;
    public int damage = 15;
    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
    }

   
    private void OnTriggerEnter(Collider other)
    {
        PlayerStats playerStats = other.GetComponent<PlayerStats>();

        if (playerStats != null)
        {
            playerStats.TakeDamage(damage);
        }

    }
}

