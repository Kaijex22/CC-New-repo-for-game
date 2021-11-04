using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class PlayerLocomotive : MonoBehaviour
    {
        Transform cameraObject;
        InputHandler inputHandler;
        Vector3 moveDirection;


        [HideInInspector]
        public Transform myTransform;
        [HideInInspector]
        public AnimatorHandler animatorHandler;

        public new Rigidbody rigidbody;
        public GameObject normalCamera;

        [Header("Stats")]
        [SerializeField]
        float movementSpeed = 5;
    [SerializeField]
    float sprintSpeed = 7;
    [SerializeField]
        float rotationSpeed = 10;

        public bool isSpritning;

        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            inputHandler = GetComponent<InputHandler>();
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            cameraObject = Camera.main.transform;
            myTransform = transform;
            animatorHandler.Inizialize();

        }

        public void Update()
        {
            float delta = Time.deltaTime;

        isSpritning = inputHandler.b_Input;
            inputHandler.TickInput(delta);
            HandleMovement(delta);

            HandleRollingAndSprinting(delta);


        }
        #region Movement
        Vector3 normalVector;

        Vector3 targetPostition;
        private void HandleRotation(float delta)
        {
            Vector3 targetDir = Vector3.zero;
            float moveOveride = inputHandler.moveAmount;

            targetDir = cameraObject.forward * inputHandler.verticle;
            targetDir += cameraObject.right * inputHandler.horizontal;

            targetDir.Normalize();
            targetDir.y = 0;

            if (targetDir == Vector3.zero)
                targetDir = myTransform.forward;

            float rs = rotationSpeed;

            Quaternion tr = Quaternion.LookRotation(targetDir);
            Quaternion targetRotation = Quaternion.Slerp(myTransform.rotation, tr, rs * delta);

            myTransform.rotation = targetRotation;
        }

        public void HandleMovement(float delta)
        {
        if (inputHandler.rollFlag)
            return;

            moveDirection = cameraObject.forward * inputHandler.verticle;
            moveDirection += cameraObject.right * inputHandler.horizontal;
            moveDirection.Normalize();
            moveDirection.y = 0;
            float speed = movementSpeed;

        if (inputHandler.sprintFlag)
        {
            speed = sprintSpeed;
            isSpritning = true;
            moveDirection *= speed;
        }
        else
        {
            moveDirection *= speed;
        }
            

            Vector3 projectedVelocity = Vector3.ProjectOnPlane(moveDirection, normalVector);
            rigidbody.velocity = projectedVelocity;

            animatorHandler.UpdateAnimatorValues(inputHandler.moveAmount, 0, isSpritning);

            if (animatorHandler.canRotate)
            {
                HandleRotation(delta);
            }
        }
        public void HandleRollingAndSprinting(float delta)
        {
            if(animatorHandler.anim.GetBool("isInteracting"))
            {
                return;
            }
            if (inputHandler.rollFlag)
            {
                moveDirection = cameraObject.forward * inputHandler.verticle;
                moveDirection = cameraObject.right * inputHandler.horizontal;
                if (inputHandler.moveAmount > 0)
                {
                    animatorHandler.PlayTargetAnimation("Roll", true);
                    moveDirection.y = 0;
                    Quaternion rollRotation = Quaternion.LookRotation(moveDirection);
                    myTransform.rotation = rollRotation;

                }
                else
                {
                    animatorHandler.PlayTargetAnimation("Backward roll", true);
                }
            }
        }


        #endregion
    }
