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
        PlayerControls inputActions;
    CameraHandler cameraHandler;

        Vector2 movementInput;
        Vector2 camerInput;
    private void Awake()
    {
        cameraHandler = CameraHandler.singleton;
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
        }
        public void MoveInput(float delta)
        {
            horizontal = movementInput.x;
            verticle = movementInput.y;
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(verticle));
            mouseX = camerInput.x;
            mouseY = camerInput.y;
        }
    }
