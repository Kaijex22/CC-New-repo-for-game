using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI Windows")]
    public PlayerInventory playerInventory;
    EquipmentWindowUi equipmentWindowUi;

    [Header("UI Windows")]
    public GameObject selectWindow;
    public GameObject hudWindow;
    public GameObject weaponInventoryWindow;

    [Header("Weapon Inventory")]
    public GameObject weaponInventorySlotPrefab;
    public Transform weaponInventorySlotsParent;
    WeaponInventorySlot[] weaponInventorySlots;

    private void Awake()
    {
        equipmentWindowUi = FindObjectOfType<EquipmentWindowUi>();
    }
    private void Start()
    {
        weaponInventorySlots = weaponInventorySlotsParent.GetComponentInChildren<WeaponInventorySlot[]>();
        equipmentWindowUi.LoadWeaponsOnEquipmentScreen(playerInventory);
    }
    public void UpdateUI()
    {
        #region Weapon Inventory Slots
        for (int i = 0; i < weaponInventorySlots.Length; i++)
        {
            if (i < playerInventory.weaponsInventory.Count)
            {
                if (weaponInventorySlots.Length < playerInventory.weaponsInventory.Count)
                {
                    Instantiate(weaponInventorySlotPrefab, weaponInventorySlotsParent);
                    weaponInventorySlots = weaponInventorySlotsParent.GetComponentInChildren<WeaponInventorySlot[]>();
                }
                weaponInventorySlots[i].AddItem(playerInventory.weaponsInventory[i]);
            }
            else
            {
                weaponInventorySlots[i].ClearInventorySlot();
            }
        }


        #endregion
    }

    public void OpenSelectWindow()
    {
        selectWindow.SetActive(true);
       
    }

    public void CloseSelectWindow()
    {
        selectWindow.SetActive(false);
        
    }

    public void CloseAllInventoryWindows()
    {
        weaponInventoryWindow.SetActive(false);
    }
}
