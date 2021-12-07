using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputHandler : MonoBehaviour
{
    public float horizontal;
    public float verticle;
    public float moveAmount;
    public float mouseX;
    public float mouseY;

    public bool b_Input;
    public bool a_Input;
    public bool rb_Input;
    public bool rt_Input;
    public bool lb_Input;
    public bool jump_input;
    public bool inventory_Input;
    public bool lockOnInput;

    public bool d_Pad_Up;
    public bool d_Pad_Down;
    public bool d_Pad_Left;
    public bool d_Pad_Right;

    public bool rollFlag;
    public bool sprintFlag;
    public bool comboFlag;
    public bool lockOnFlag;
    public bool inventoryFlag;


    public float rollInputTimer;
    public bool isInteracting;

    PlayerControls inputActions;
    CameraHandler cameraHandler;
    PlayerAttacker playerAttacker;
    PlayerInventory playerInventory;
    PlayerManager playerManager;
    BlockingCollider blockingCollider;
    UIManager uIManager;
    InputHandler inputHandler;
    AnimatorHandler animatorHandler;

    Vector2 movementInput;
    Vector2 camerInput;
    private void Awake()
    {
        cameraHandler = CameraHandler.singleton;
        playerAttacker = GetComponent<PlayerAttacker>();
        playerInventory = GetComponent<PlayerInventory>();
        playerManager = GetComponent<PlayerManager>();
        uIManager = FindObjectOfType<UIManager>();
        animatorHandler = GetComponent<AnimatorHandler>();
        inputHandler = GetComponent<InputHandler>();
        blockingCollider = GetComponentInChildren<BlockingCollider>();
    }
    private void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime;
        if (cameraHandler != null)
        {
            cameraHandler.FollowTarget(delta);
            cameraHandler.HandleCameraRotation(delta, mouseX, mouseY);
        }
    }
    public void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new PlayerControls();
            inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
            inputActions.PlayerMovement.Camera.performed += i => camerInput = i.ReadValue<Vector2>();
            inputActions.PlayerActions.LockOn.performed += i => lockOnInput = true;
            inputActions.PlayerActions.LB.performed += i => lb_Input = true;
            inputActions.PlayerActions.LB.canceled += i => lb_Input = false;
        }

        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
    public void TickInput(float delta)
    {
        MoveInput(delta);
        HandleRollInput(delta);
        HandleAttackInput(delta);
        HandleQuickSlotInput();
        HandleInteractableButtonInput();
        HandleJumpInput();
        HandleInventoryInput();
        HandleLockOnInput();
        
    }
    public void MoveInput(float delta)
    {
        horizontal = movementInput.x;
        verticle = movementInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(verticle));
        mouseX = camerInput.x;
        mouseY = camerInput.y;
        

    }
    private void HandleRollInput(float delta)
    {
        b_Input = inputActions.PlayerActions.Roll.phase == UnityEngine.InputSystem.InputActionPhase.Started;
        if (b_Input)
        {
           
            rollInputTimer += delta;
            sprintFlag = true;
        }
        else
        {
            if(rollInputTimer > 0 && rollInputTimer < 0.5f)
            {
                sprintFlag = false;
                rollFlag = true;
            }
            rollInputTimer = 0;
        }
    }

    private void HandleAttackInput(float delta)
    {
        inputActions.PlayerActions.RB.performed += I => rb_Input = true;
        inputActions.PlayerActions.RT.performed += I => rt_Input = true;

        if (rb_Input)
        {

            if (playerManager.canDoCombo)
            {
                comboFlag = true;
                playerAttacker.HandleWeaponCombo(playerInventory.rightWeapon);
                comboFlag = false;
            }
            else
            {
                if (isInteracting)
                {
                    return;
                }
                if (playerManager.canDoCombo)
                {
                    return;
                }
                playerAttacker.HandleLightAttack(playerInventory.rightWeapon);
            }
           
        }
        if (rt_Input)
        {
            playerAttacker.HandleHeavyAttack(playerInventory.rightWeapon);
        }
        if (lb_Input)
        {
            
            playerAttacker.HandleLBAction();
           
        }
        else
        {
            playerManager.isBlocking = false;

            if (blockingCollider.blockingCollider.enabled)
            {
                blockingCollider.DisableBlockingCollider();
            }
        }
    }

    private void HandleQuickSlotInput()
    {
        inputActions.Inventory.DPadRight.performed += i => d_Pad_Right = true;
        inputActions.Inventory.DPadLeft.performed += i => d_Pad_Left = true;

        if (d_Pad_Right)
        {
            playerInventory.ChangeRightWeapon();
            FindObjectOfType<AudioManager>().Play("SwordEquip");
        }

        else if (d_Pad_Left)
        {
            playerInventory.ChangeLeftWeapon();
            FindObjectOfType<AudioManager>().Play("SwordEquip");
        }
    }
    private void HandleInteractableButtonInput()
    {
        inputActions.PlayerActions.a_Input.performed += i => a_Input = true;

        
    }
    
    private void HandleJumpInput()
    {
        inputActions.PlayerActions.jump_Input.performed += i => jump_input = true;
    }
    private void HandleInventoryInput()
    {
        inputActions.PlayerActions.Inventory.performed += i => inventory_Input = true;

        if (inventory_Input)
        {
            inventoryFlag = !inventoryFlag;

            if (inventoryFlag)
            {
                uIManager.OpenSelectWindow();
                uIManager.UpdateUI();
                uIManager.hudWindow.SetActive(false);
            }
            else
            {
                uIManager.CloseSelectWindow();
                uIManager.CloseAllInventoryWindows();
                uIManager.hudWindow.SetActive(true);
            }
        }
    }

    private void HandleLockOnInput()
    {
        if(lockOnInput && lockOnFlag == false)
        {
            cameraHandler.ClearLockOnTargets();
            lockOnInput = false;
            lockOnFlag = true;
            
            cameraHandler.HandleLockOn();
            if(cameraHandler.nearestLockOnTarget != null)
            {
                cameraHandler.currentLockOnTarget = cameraHandler.nearestLockOnTarget;
                lockOnFlag = true;
            }
        }
        else if (lockOnInput && lockOnFlag)
        {
            lockOnInput = false;
            lockOnFlag = false;
            cameraHandler.ClearLockOnTargets();
        }
    }
   

   
}