using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CharacterManager
{

    InputHandler inputHandler;
    Animator anim;
    public bool isInAir;
    public bool isGrounded;
    PlayerLocomotive playerLocomotive;
    public CameraHandler cameraHandler;
    InteractableUI interactableUI;

    public bool canDoCombo;
    public GameObject interactableUiGameObject;
    public bool isBlocking;

    // Start is called before the first frame update
    void Start()
    {
        inputHandler = GetComponent<InputHandler>();
        anim = GetComponentInChildren<Animator>();
        playerLocomotive = GetComponent<PlayerLocomotive>();
        interactableUI = FindObjectOfType<InteractableUI>();

    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.fixedDeltaTime;
        canDoCombo = anim.GetBool("canDoCombo");
        anim.SetBool("isInAir", isInAir);
        anim.SetBool("isBlocking", isBlocking);
        inputHandler.isInteracting = anim.GetBool("isInteracting");
        inputHandler.rollFlag = false;
        inputHandler.sprintFlag = false;
        playerLocomotive.HandleFalling(delta, playerLocomotive.moveDirection);
       

        playerLocomotive.HandleJumping();

    }

    private void LateUpdate()
    {
        if (isInAir)
        {
            playerLocomotive.inAirTimer = playerLocomotive.inAirTimer + Time.deltaTime;
        }
        inputHandler.rb_Input = false;
        inputHandler.rt_Input = false;
        inputHandler.d_Pad_Up = false;
        inputHandler.d_Pad_Down = false;
        inputHandler.d_Pad_Left = false;
        inputHandler.d_Pad_Right = false;
        inputHandler.a_Input = false;
        inputHandler.jump_input = false;
        inputHandler.inventory_Input = false;
    }
   
     


    #region Singleton

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;

}
