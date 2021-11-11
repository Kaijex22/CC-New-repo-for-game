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
    public CameraHandler cameraHandler;
    InteractableUI interactableUI;

    public bool canDoCombo;
    public GameObject interactableUiGameObject;

  
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
        inputHandler.isInteracting = anim.GetBool("isInteracting");
        inputHandler.rollFlag = false;
        inputHandler.sprintFlag = false;
        playerLocomotive.HandleFalling(delta, playerLocomotive.moveDirection);
        CheckForInteractableObject();

        playerLocomotive.HandleJumping();

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
        inputHandler.a_Input = false;
        inputHandler.jump_input = false;
        inputHandler.inventory_Input = false;
    }
    public void CheckForInteractableObject()
    {
        RaycastHit hit;

        if(Physics.SphereCast(transform.position, 0.3f, transform.forward, out hit, 1f, cameraHandler.ignoreLayers))
        {
            if(hit.collider.tag == "Interactable")
            {
                Interactable interactableObject = hit.collider.GetComponent<Interactable>();
                if(interactableObject != null)
                {
                    string interactableText = interactableObject.interactableText;
                    interactableUI.InteractableText.text = interactableText;
                    interactableUiGameObject.SetActive(true);


                    if (inputHandler.a_Input)
                    {
                        hit.collider.GetComponent<Interactable>().Interact(this);
                    }
                }
            }
        }
        else
        {
            if(interactableUiGameObject != null)
            {
                interactableUiGameObject.SetActive(false);
            }
        }
    }
}
