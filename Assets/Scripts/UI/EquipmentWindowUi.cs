using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentWindowUi : MonoBehaviour
{
    public bool rightHandSlot_01Selected;
    public bool rightHandSlot_02Selected;
    public bool leftHandSlot_01Selected;
    public bool leftHandSlot_02Selected;

    HandleEquipmentSlotUi[] handleEquipmentSlotUI;


    private void Start()
    {
        handleEquipmentSlotUI = GetComponentsInChildren<HandleEquipmentSlotUi>();
    }


    public void LoadWeaponsOnEquipmentScreen(PlayerInventory playerInventory)
    {
        for (int i = 0; i < handleEquipmentSlotUI.Length; i++)
        {
            if (handleEquipmentSlotUI[i].rightHandSlot01)
            {
                handleEquipmentSlotUI[i].AddItem(playerInventory.weaponsInRightHandSlots[0]);
            }
            else if (handleEquipmentSlotUI[i].rightHandSlot02)
            {
                handleEquipmentSlotUI[i].AddItem(playerInventory.weaponsInRightHandSlots[1]);

            }
            else if (handleEquipmentSlotUI[i].leftHandSlot01)
            {
                handleEquipmentSlotUI[i].AddItem(playerInventory.weaponsInLeftHandSlots[0]);

            }
            else
            {
                handleEquipmentSlotUI[i].AddItem(playerInventory.weaponsInLeftHandSlots[1]);
            }
        }

      
    }
    public void SelectRightHandSlot01()
    {
        rightHandSlot_01Selected = true;
    }
    public void SelectRightHandSlot02()
    {
        rightHandSlot_02Selected = true;
    }
    public void SelectLeftHandSlot01()
    {
        leftHandSlot_01Selected = true;
    }
    public void SelectLeftHandSlot02()
    {
        leftHandSlot_02Selected = true;
    }
}
