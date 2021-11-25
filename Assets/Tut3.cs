using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tut3 : MonoBehaviour
{
    public GameObject infoPanel3;
    Tutorial2 tutorial2;

    private void Awake()
    {
        tutorial2 = GetComponent<Tutorial2>();
    }
    private void OnTriggerEnter(Collider other)
    {
        infoPanel3.SetActive(true);
        tutorial2.infoPanel2.SetActive(false);
    
}
}

