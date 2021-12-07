using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    SceneManager sceneManager;

    private void Awake()
    {
        sceneManager = GetComponent<SceneManager>();

    }

    public void Backtomenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
