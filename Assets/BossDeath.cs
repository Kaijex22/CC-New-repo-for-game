using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDeath : MonoBehaviour
{
    public EnemyStats enemyStats;

    public GameObject youWin;
    InputHandler inputHandler;

    private float delayBeforeLoading = 6f;

    private float timeElapsed;
    private void Awake()
    {
        inputHandler = GetComponent<InputHandler>();
    }
    private void Update()
    {
        isDead();
    }


    public void isDead()
    {
        
        if (enemyStats.currentHealth <= 0)
        {
            FindObjectOfType<AudioManager>().Play("Boss Death");
            youWin.gameObject.SetActive(true);

            timeElapsed += Time.deltaTime;

            if (timeElapsed > delayBeforeLoading)
            {
                SceneManager.LoadScene("Credits");
                inputHandler.isInteracting = true;
            }

        }
    }
}
