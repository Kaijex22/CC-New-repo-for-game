using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingCollider : MonoBehaviour
{
    public BoxCollider blockingCollider;

    public float blockingPhyscialDamageAbsorption;

    private void Awake()
    {
        blockingCollider = GetComponent<BoxCollider>();
    }

    public void SetColliderDamageAbosrption(WeaponItem weapon)
    {
        if (weapon != null)
        {
            blockingPhyscialDamageAbsorption = weapon.physicalDamageAbsorption;

        }
    }

    public void EnableBlockingCollider()
    {
        blockingCollider.enabled = true;
    }
    public void DisableBlockingCollider()
    {
        blockingCollider.enabled = false;
    }
}
