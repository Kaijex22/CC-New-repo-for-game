using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnScript : MonoBehaviour
{
    PlayerStats playerStats;

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    public void Respawn()
    {
        if(playerStats.currentHealth == 0)
        {
            playerStats.currentHealth = 0;

            SceneManager.LoadScene("BossFight");
        }
    }
}
