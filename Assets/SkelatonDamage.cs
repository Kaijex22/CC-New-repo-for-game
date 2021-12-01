using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkelatonDamage : MonoBehaviour
{
    AnimatorHandler animatorHandler;
    PlayerStats playerStats;
    public int damage = 15;
    public Collider collider;

    private void Awake()
    {
        animatorHandler = GetComponent<AnimatorHandler>();
        playerStats = GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerStats playerStats = other.GetComponent<PlayerStats>();

        if(playerStats!= null)
        {
            playerStats.TakeDamage(damage);
            
        }
        

        
    }
}
