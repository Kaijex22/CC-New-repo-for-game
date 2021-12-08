using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventColliderBeginFIght : MonoBehaviour
{
    WorldEventManager worldEventManager;

    private void Awake()
    {
        worldEventManager = FindObjectOfType<WorldEventManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            worldEventManager.ActiveateBossFight();
            FindObjectOfType<AudioManager>().Play("Boss Theme");
        }
    }
}
