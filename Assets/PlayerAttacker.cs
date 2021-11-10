using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{

    AnimatorHandler animatorHandler;
    public string lastAttack;
    InputHandler inputHandler;

    private void Awake()
    {
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
        inputHandler = GetComponent<InputHandler>();
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
    public void HandleLightAttack(WeaponItem weapon)
    {
        animatorHandler.PlayTargetAnimation(weapon.OH_Light_Attack_1, true);
        lastAttack = weapon.OH_Light_Attack_1;
    }
    public void HandleHeavyAttack(WeaponItem weapon)
    {
        animatorHandler.PlayTargetAnimation(weapon.OH_Heavy_Attack_1, true);
        lastAttack = weapon.OH_Heavy_Attack_1;
    }
}
