using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleEquipmentSlotUi : MonoBehaviour
{
    public Image Icon;
    WeaponItem weapon;

    public bool rightHandSlot01;
    public bool rightHandSlot02;
    public bool leftHandSlot01;
    public bool leftHandSlot02;

    public void AddItem(WeaponItem newWeapon)
    {
        weapon = newWeapon;
        Icon.sprite = weapon.itemIcon;
        Icon.enabled = true;
        gameObject.SetActive(true);
    }

    public void ClearItem()
    {
        weapon = null;
        Icon.sprite = null;
        Icon.enabled = false;
        gameObject.SetActive(false);
    }
}
