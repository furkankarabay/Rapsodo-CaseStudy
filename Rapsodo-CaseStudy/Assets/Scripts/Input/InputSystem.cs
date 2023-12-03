using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    PlayerControls playerControls;
    private PlayerLocomotion playerLocomotion;
    private PlayerAnimator animatorManager;

    private Vector2 movementInput;
    private float moveAmount;

    private bool jump_Input;

    [HideInInspector] public float verticalInput;
    [HideInInspector] public float horizontalInput;
    private void Awake()
    {
        animatorManager = GetComponent<PlayerAnimator>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();

            playerControls.FindAction("Jump").performed += i => jump_Input = true;

        }

        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInputs()
    {
        HandeMovementInput();
        HandeJumpingInput();
        //Handle Action Input
    }

    private void HandeMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount);
    }

    private void HandeJumpingInput()
    {
        if(jump_Input)
        {
            jump_Input = false;
            playerLocomotion.HandleJumping();
        }
    }
}
