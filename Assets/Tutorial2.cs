using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial2 : MonoBehaviour
{
    public GameObject infoPanel2;
    public GameObject infopanel1disable;
    Tutorial1 tutorial1;
    private void Awake()
    {
        tutorial1 = GetComponent<Tutorial1>();
    }
   
    private void OnTriggerEnter(Collider other)
    {
        infoPanel2.SetActive(true);

        infopanel1disable.SetActive(false);
    }
}
