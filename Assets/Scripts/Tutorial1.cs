using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial1 : MonoBehaviour
{
    public GameObject infoPanel1;


    private void OnTriggerEnter(Collider other)
    {
        infoPanel1.SetActive(true);
    }
}
