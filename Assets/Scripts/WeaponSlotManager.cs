using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotManager : MonoBehaviour
{
    WeaponHolderSlot leftHandSlot;
    WeaponHolderSlot rightHandSlot;

    DamageCollider leftHandDamageCollider;
    DamageCollider rightHandDamageCollider;

    public WeaponItem attackingWeapon;
    QuickSlotsUi quickSlotsUi;
    PlayerManager playerManager;
    PlayerStats playerStats;

    private void Awake()
    {
        quickSlotsUi = FindObjectOfType<QuickSlotsUi>();
        WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
        playerStats = GetComponentInParent<PlayerStats>();
        foreach (WeaponHolderSlot weaponSlot in weaponHolderSlots)
        {
            if (weaponSlot.isLeftHandSlot)
            {
                leftHandSlot = weaponSlot;
            }
            else if (weaponSlot.isRightHandSlot)
            {
                rightHandSlot = weaponSlot;
            }
        }
    }

    public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isLeft)
    {
        if (isLeft)
        {
            leftHandSlot.LoadWeaponModel(weaponItem);
            loadLeftWeaponCollider();
            quickSlotsUi.UpdateWeaponQuickSlotsUi(true, weaponItem);
        }
        else
        {
            rightHandSlot.LoadWeaponModel(weaponItem);
            LoadRightWeaponCollider();
            quickSlotsUi.UpdateWeaponQuickSlotsUi(false, weaponItem);
        }



    }
    #region Handle Weapon's Damage Collider
    private void LoadRightWeaponCollider()
    {
        rightHandDamageCollider = rightHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
    }
    private void loadLeftWeaponCollider()
    {
        leftHandDamageCollider = leftHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
    }
    public void OpenRightDamageCollider()
    {
        if (playerManager.isUsingRightHand)
        {
            rightHandDamageCollider.EnableDamageCollider();
        }
        else if (playerManager.isUsingLeftHand)
        {
            leftHandDamageCollider.EnableDamageCollider();
        }
        
    }

    public void CloseRightHandDamageCollider()
    {
        rightHandDamageCollider.DisableDamageCollider();
        leftHandDamageCollider.DisableDamageCollider();
    }
    #endregion
    #region Handle Weapon Stamina Drainage
    public void DrainStaminaLightAttack()
    {
        playerStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.lightAttackMultiplier));
    }
    public void DrainStaminaHeavyAttack()
    {
        playerStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.heavyAttackMultiplier));
    }
    #endregion
}