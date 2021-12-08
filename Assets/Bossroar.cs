using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossroar : StateMachineBehaviour
{
    public void Roarsound()
    {
        FindObjectOfType<AudioManager>().Play("RoarSound");
    }
}
