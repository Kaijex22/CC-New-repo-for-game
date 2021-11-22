using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class EnemyAnimatorManager : AnimatorManager
    {
        EnemyLocomotionManager enemyLocomotionManager;
    public GameObject enemyRigidBody;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            enemyLocomotionManager = GetComponentInParent<EnemyLocomotionManager>();
        }

        private void OnAnimatorMove()
        {
          
        }
    }
