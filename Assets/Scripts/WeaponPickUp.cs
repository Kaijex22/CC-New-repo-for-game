using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : Interactable
{
    public WeaponItem weapon;

    public override void Interact(PlayerManager playerManager)
    {
        base.Interact(playerManager);
        Debug.Log("You picked up an objectt");
        PickUpItem(playerManager);
    }

    private void PickUpItem(PlayerManager playerManager)
    {
        PlayerInventory playerInventory;
        PlayerLocomotive playerLocomotive;
        AnimatorHandler animatorHandler;

        playerLocomotive = GetComponent<PlayerLocomotive>();
        playerInventory = GetComponent<PlayerInventory>();
        animatorHandler = GetComponentInChildren<AnimatorHandler>();

        playerLocomotive.rigidbody.velocity = Vector3.zero; // stops thje player from moving whilst pickiong up
        animatorHandler.PlayTargetAnimation("Pick Up Item", true);
        playerInventory.weaponsInventory.Add(weapon);
        Debug.Log("You picked up an objectt");
        Destroy(gameObject);
    }
} 

