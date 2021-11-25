using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{

    AnimatorHandler animatorHandler;
    PlayerEquipmentManager playerEquipmentManager;
    public string lastAttack;
    InputHandler inputHandler;
    WeaponSlotManager weaponSlotManager;
    public PlayerManager playerManager;

    private void Awake()
    {
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
        inputHandler = GetComponent<InputHandler>();
        weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();

        playerEquipmentManager = GetComponent<PlayerEquipmentManager>();
    }

    public void HandleWeaponCombo(WeaponItem weapon)
    {
        if (inputHandler.comboFlag)
        {
            animatorHandler.anim.SetBool("canDoCombo", false);
            if (lastAttack == weapon.OH_Light_Attack_1)
            {
                animatorHandler.PlayTargetAnimation(weapon.OH_Light_Attack_1, true);
            }
        }
        
    }
    public void HandleLBAction()
    {
        PerformLBBlockingAction();
    }
    public void HandleLightAttack(WeaponItem weapon)
    {
        weaponSlotManager.attackingWeapon = weapon;
        animatorHandler.PlayTargetAnimation(weapon.OH_Light_Attack_1, true);
        lastAttack = weapon.OH_Light_Attack_1;
    }
    public void HandleHeavyAttack(WeaponItem weapon)
    {
        weaponSlotManager.attackingWeapon = weapon;
        animatorHandler.PlayTargetAnimation(weapon.OH_Heavy_Attack_1, true);
        lastAttack = weapon.OH_Heavy_Attack_1;
    }
    #region Defense actions
    private void PerformLBBlockingAction()
    {
        if (inputHandler.isInteracting)
        {
            return;
        }
        if (playerManager.isBlocking)
        {
            return;
        }

        animatorHandler.PlayTargetAnimation("Block Start", false);
        playerEquipmentManager.OpenBlockingCollider();
        playerManager.isBlocking = true;
    }
    #endregion
}
