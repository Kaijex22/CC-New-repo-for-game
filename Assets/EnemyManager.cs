using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : CharacterManager
{
    EnemyLocomotionManager enemyLocomotionManager;
    public bool isPerformingAction;
    [Header("A.I Settings")]
    public float detectionRadius = 20;
    // THe higher, and lower, respectively these angles are , the greater detection FOV
    public float maximumDetectionAngle = 50;
    public float minimumDetectionAngle = -50;
    private void Awake()
    {
        enemyLocomotionManager = GetComponent<EnemyLocomotionManager>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        HandleCurrentActions();

        
    }

    private void HandleCurrentActions()
    {
        if(enemyLocomotionManager.currentTarget = null)
        {
            enemyLocomotionManager.HandleDetection();
        }
        else
        {
            enemyLocomotionManager.HandleMoveToTarget();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; //replace red with whatever color you prefer
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
