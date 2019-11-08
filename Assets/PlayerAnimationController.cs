using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Gameplay
{
    public class PlayerAnimationController : MonoBehaviour
    {
        private PlayerMovementController playerMovementController;
        private Animator animator;

        void Awake()
        {
            playerMovementController = GetComponent<PlayerMovementController>();
            animator = GetComponent<Animator>();
        }
        
        void Update()
        {
            Vector3 direction = playerMovementController.GetDirection();
            if (direction != Vector3.zero)
            {
                animator.SetBool("Run", true);
                if (direction.x > 0)
                {
                    animator.SetBool("Right", true);
                }
                else
                {
                    animator.SetBool("Right", false);
                }
            }
            else
            {
                animator.SetBool("Run", false);
            }
        }
    }
}