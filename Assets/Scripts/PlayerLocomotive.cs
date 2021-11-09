using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class PlayerLocomotive : MonoBehaviour
    {
        Transform cameraObject;
        InputHandler inputHandler;
       public Vector3 moveDirection;
    public PlayerManager playerManager;
    


        [HideInInspector]
        public Transform myTransform;
        [HideInInspector]
        public AnimatorHandler animatorHandler;

        public new Rigidbody rigidbody;
        public GameObject normalCamera;

    [Header("Ground & air detection stats")]

    [SerializeField]
    float groundDetectionRayStartPoint = 0.5f;
    [SerializeField]
    float minimumDistanceNeededToBeginFall = 1f;
    [SerializeField]
    float groundDirectionRayDistance = 0.2f;
    LayerMask ignoreForGroundCheck;
    public float inAirTimer;




    [Header("Stats")]
        [SerializeField]
        float movementSpeed = 5;
    [SerializeField]
    float sprintSpeed = 7;
    [SerializeField]
        float rotationSpeed = 10;
    [SerializeField]
    float fallingSpeed = 45;

    public bool isSpritning;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        inputHandler = GetComponent<InputHandler>();
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
        cameraObject = Camera.main.transform;
        myTransform = transform;
        animatorHandler.Inizialize();
        playerManager.GetComponent<PlayerManager>();

        playerManager.isGrounded = true;
        ignoreForGroundCheck = ~(1 << 8 | 1 << 11);

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

        if (inputHandler.sprintFlag && inputHandler.moveAmount > 0.5)
        {
            speed = sprintSpeed;
            isSpritning = true;
            moveDirection *= speed;
        }
        else
        {
            moveDirection *= speed;
            isSpritning = false;
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
    public void HandleFalling(float delta, Vector3 moveDirection)
    {
        playerManager.isGrounded = false;
        RaycastHit hit;
        Vector3 origin = myTransform.position;
        origin.y += groundDetectionRayStartPoint;
        if (Physics.Raycast(origin, myTransform.forward, out hit, 0.4f))
        {
            moveDirection = Vector3.zero;
        }
        if (playerManager.isInAir)
        {
            rigidbody.AddForce(-Vector3.up * fallingSpeed);
            rigidbody.AddForce(moveDirection * fallingSpeed / 5f);
        }
        Vector3 dir = moveDirection;
        dir.Normalize();
        origin = origin + dir * groundDirectionRayDistance;

        targetPostition = myTransform.position;
        Debug.DrawRay(origin, -Vector3.up * minimumDistanceNeededToBeginFall, Color.red, 0.1f, false);
        if (Physics.Raycast(origin, -Vector3.up, out hit, minimumDistanceNeededToBeginFall, ignoreForGroundCheck))
        {
            normalVector = hit.normal;
            Vector3 tp = hit.point;
            playerManager.isGrounded = true;
            targetPostition.y = tp.y;

            if(playerManager.isInAir)
            {
                if (inAirTimer > 0.5f)
                {
                    Debug.Log("You were in the air for " + inAirTimer);
                    animatorHandler.PlayTargetAnimation("Land", true);
                }
                else
                {
                    animatorHandler.PlayTargetAnimation("Empty", false);
                    inAirTimer = 0;
                }
                playerManager.isInAir = false;

            }    
        }
        else
        {
            if (playerManager.isGrounded)
            {
                playerManager.isGrounded = false;
            }
            if (playerManager.isInAir == false)
            {
                if(inputHandler.isInteracting == false)
                {
                    animatorHandler.PlayTargetAnimation("Falling", true);
                }
                Vector3 vel = rigidbody.velocity;
                vel.Normalize();
                rigidbody.velocity = vel * (movementSpeed / 2);
                playerManager.isInAir = true;
            }
        }

        if (playerManager.isGrounded)
        {
            if(inputHandler.isInteracting || inputHandler.moveAmount > 0)
            {
                myTransform.position = Vector3.Lerp(myTransform.position, targetPostition, Time.deltaTime);

            }
            else
            {
                myTransform.position = targetPostition;
            }
        }
        if (inputHandler.isInteracting || inputHandler.moveAmount > 0)
        {
            myTransform.position = Vector3.Lerp(myTransform.position, targetPostition, Time.deltaTime / 0.1f);
        }
        else
        {
            myTransform.position = targetPostition;
        }
        if (inputHandler.isInteracting || inputHandler.moveAmount > 0)
        {
            myTransform.position = Vector3.Lerp(myTransform.position, targetPostition, Time.deltaTime / 0.1f);
        }
        else
        {
            myTransform.position = targetPostition;
        }
    }
    


    #endregion
}
