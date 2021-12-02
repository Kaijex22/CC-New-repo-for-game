using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageCollider: MonoBehaviour
{
    Collider damageCollider;
    PlayerStats playerStats;
    public int currentWeaponDamage = 25;
    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
        damageCollider = GetComponent<Collider>();
        damageCollider.gameObject.SetActive(true);
        damageCollider.isTrigger = true;
        damageCollider.enabled = false;
    }

    public void EnableDamageCollider()
    {
        damageCollider.enabled = true;

    }
    public void DisableDamageCollider()
    {
        damageCollider.enabled = false;

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Enemy")
        {
            PlayerStats player = collision.GetComponent<PlayerStats>();
            BlockingCollider sword = collision.transform.GetComponentInChildren<BlockingCollider>();



            if (playerStats != null)
            {
                playerStats.TakeDamage(currentWeaponDamage);
            }
        }
        if (collision.tag == "Player")
        {
            PlayerStats playerStats = collision.GetComponent<PlayerStats>();

            if (playerStats != null)
            {
                playerStats.TakeDamage(currentWeaponDamage);
            }
        }
    }
}
