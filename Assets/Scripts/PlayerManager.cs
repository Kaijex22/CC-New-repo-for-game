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
      


    }

    private void LateUpdate()
    {
        if(isInAir)
        {
            playerLocomotive.inAirTimer = playerLocomotive.inAirTimer + Time.deltaTime;
        }
    }

}
