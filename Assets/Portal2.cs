using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal2 : MonoBehaviour
{
    public GameObject portal;
    public GameObject boss;
    EnemyStats enemyStats;

    private void Awake()
    {
        enemyStats = GetComponent<EnemyStats>();
    }


    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Final Lava level");
    }
}
