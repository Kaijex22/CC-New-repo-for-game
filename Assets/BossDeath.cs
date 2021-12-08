using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDeath : MonoBehaviour
{
    public EnemyStats enemyStats;

    public GameObject youWin;

    private float delayBeforeLoading = 10f;

    private float timeElapsed;

    private void Update()
    {
        isDead();
    }


    public void isDead()
    {
        
        if (enemyStats.currentHealth == 0)
        {
            FindObjectOfType<AudioManager>().Play("Boss Death");
            youWin.gameObject.SetActive(true);

            timeElapsed += Time.deltaTime;

            if (timeElapsed > delayBeforeLoading)
            {
                SceneManager.LoadScene("Credits");
            }

        }
    }
}
