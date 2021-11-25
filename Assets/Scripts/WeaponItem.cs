using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Items/Weapon Item")]
public class WeaponItem : Item
{
  

    public GameObject modelPrefab;
    public bool isUnarmed;
    [Header("Absorption")]
    public float physicalDamageAbsorption;

    [Header("One Handed Attack Animations")]

    public string OH_Light_Attack_1;
    public string OH_Heavy_Attack_1;

    [Header("Stamina Costs")]
    public int baseStamina;
    public float lightAttackMultiplier;
    public float heavyAttackMultiplier;
}
