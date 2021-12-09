using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackToStartScript : MonoBehaviour
{
    private float delayBeforeLoading = 14f;

    private float timeElapsed;

    public GameObject button;

    

    public void BackTomainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
