using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level1Respawn : MonoBehaviour
{
    PlayerStats playerStats;
    public GameObject button;
    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    public void buttons(int currentHealth)
    {
        if(playerStats.currentHealth == 0)
        {
            button.gameObject.SetActive(true);

        }
    }


    public void loadcurrentScnee()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
