using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    
    InputHandler inputHandler;
    Animator anim;
    public bool isInAir;
    public bool isGrounded;
    PlayerLocomotive playerLocomotive;

    public bool canDoCombo;


  
    // Start is called before the first frame update
    void Start()
    {
        inputHandler = GetComponent<InputHandler>();
        anim = GetComponentInChildren<Animator>();
        playerLocomotive = GetComponent<PlayerLocomotive>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.fixedDeltaTime;

        inputHandler.isInteracting = anim.GetBool("isInteracting");
        inputHandler.rollFlag = false;
        inputHandler.sprintFlag = false;
        playerLocomotive.HandleFalling(delta, playerLocomotive.moveDirection);

        canDoCombo = anim.GetBool("canDoCombo");
      


    }

    private void LateUpdate()
    {
        if(isInAir)
        {
            playerLocomotive.inAirTimer = playerLocomotive.inAirTimer + Time.deltaTime;
        }
        inputHandler.rb_Input = false;
        inputHandler.rt_Input = false;
        inputHandler.d_Pad_Up = false;
        inputHandler.d_Pad_Down = false;
        inputHandler.d_Pad_Left = false;
        inputHandler.d_Pad_Right = false;
    }

}
