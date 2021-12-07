using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public Transform player;

    public bool isStunned = false;

    public void LookAtPlayer()
    {
        Vector3 stunned = transform.localScale;
        stunned.z *= -1f;

        if (transform.position.x > player.position.x && isStunned)
        {
            transform.localScale = stunned;
            transform.Rotate(0f, 180f, 0f);
            isStunned = false;
        }
        else if (transform.position.x < player.position.x && !isStunned)
        {
            transform.localScale = stunned;
            transform.Rotate(0f, 180f, 0f);
            isStunned = true;
        }

    }
}
