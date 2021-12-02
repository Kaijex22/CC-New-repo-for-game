using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRuntutorial : MonoBehaviour
{
    public Transform playerCam;
    public Transform orientation;


    private Rigidbody rb;
    InputHandler inputHandler;
    PlayerControls inputActions;


    private float xRotation;
    private float sensitivity = 50;
    private float sensMulitplier = 1f;



    public LayerMask whatIsWall;
    public float wallrunForce, maxWallrunTime, maxwallSpeed;
    bool isWallRight, isWallLeft;
    bool isWallRunning;
    public float maxWallRunCameraTilt, wallRunCameraTilt;

    private void Awake()
    {
        inputHandler = GetComponent<InputHandler>();
    }

    private void WallRunInput()
    {
        
    }

    private void StartWallRun()
    {

    }
    private void StopWallRun()
    {


    }

    private void CheckForWall()
    {
        isWallRight = Physics.Raycast(transform.position, orientation.right, 1f, whatIsWall);
        isWallLeft = Physics.Raycast(transform.position, -orientation.right, 1f, whatIsWall);

    }

    
}
