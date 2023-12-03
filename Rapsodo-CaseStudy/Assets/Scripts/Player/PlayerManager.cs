using UnityEngine;

namespace Rapsodo.MazeGame
{
    public class PlayerManager : MonoBehaviour
    {
        private Animator playerAnimator;
        private InputSystem inputManager;
        private PlayerLocomotion playerLocomotion;
        public bool IsInteracting { get; private set; }

        private void Awake()
        {
            inputManager = GetComponent<InputSystem>();
            playerLocomotion = GetComponent<PlayerLocomotion>();
            playerAnimator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (!GameManager.hasGameStarted || GameManager.hasGameFinished)
                return;

            inputManager.HandleAllInputs();
        }

        private void FixedUpdate()
        {
            if (!GameManager.hasGameStarted || GameManager.hasGameFinished)
                return;

            playerLocomotion.HandleAllMovement();
        }

        private void LateUpdate()
        {
            playerLocomotion.IsJumping = playerAnimator.GetBool("isJumping");

            IsInteracting = playerAnimator.GetBool("isInteracting");

            playerLocomotion.IsJumping = playerAnimator.GetBool("isJumping");

            playerAnimator.SetBool("isGrounded", playerLocomotion.IsGrounded);
        }
    }

}
