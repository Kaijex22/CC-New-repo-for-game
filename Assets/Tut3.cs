using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tut3 : MonoBehaviour
{
    public GameObject infoPanel3;
    public GameObject infoPanel2disable;
    Tutorial2 tutorial2;

    private void Awake()
    {
        tutorial2 = GetComponent<Tutorial2>();
    }
    private void OnTriggerEnter(Collider other)
    {
        infoPanel3.SetActive(true);
        infoPanel2disable.SetActive(false);
    
}
    private void OnTriggerExit(Collider other)
    {
        infoPanel3.SetActive(false);
    }
}

