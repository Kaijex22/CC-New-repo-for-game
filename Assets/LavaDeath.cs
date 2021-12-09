using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LavaDeath : MonoBehaviour
{
    PlayerStats playerStats;

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
    }
    private void OnTriggerEnter(Collider other)
    {
        playerStats.currentHealth = 0;
        SceneManager.LoadScene("Final Lava level");
    }
}
