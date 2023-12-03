using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{

    private PlayerManager playerManager;
    private PlayerAnimator animatorManager;
    private InputSystem inputManager;

    private Vector3 moveDirection;
    private Transform cameraObject;
    private Rigidbody playerRigidbody;

    [Header("Falling")]
    [SerializeField] private float inAirTimer;
    [SerializeField] private float leapingVelocity;
    [SerializeField] private float fallingVelocity;
    [SerializeField] private float raycastHeightOffset = 0.5f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Movement Speeds")]
    [SerializeField] private float runningSpeed = 5;
    [SerializeField] private float rotationSpeed = 15;

    [Header("Jumping")]
    [SerializeField] private float jumpHeight = 3;
    [SerializeField] private float gravityIntensity = -15;
    [SerializeField] private float cooldown = 1;
    public bool CanJump = true;

    [Header("Movement Flags")] 
    public bool IsJumping;
    public bool IsGrounded;


    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        animatorManager = GetComponent<PlayerAnimator>();
        inputManager = GetComponent<InputSystem>();
        playerRigidbody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    public void HandleAllMovement()
    {
        HandleFallingAndLanding();

        if (playerManager.IsInteracting || !IsGrounded)
            return;

        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        if (IsJumping)
            return;

        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput;

        moveDirection.Normalize();

        moveDirection.y = 0;
        moveDirection = moveDirection * runningSpeed;


        Vector3 movementVelocity = moveDirection;

        playerRigidbody.velocity = movementVelocity;
    }

    private void HandleRotation()
    {
        if (IsJumping)
            return;

        Vector3 targetDirection = Vector3.zero;

        targetDirection = cameraObject.forward * inputManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right * inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
            targetDirection = transform.forward;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }

    private void HandleFallingAndLanding()
    {
        Vector3 raycastOrigin = transform.position - Vector3.up / 2;
        raycastOrigin.y = raycastOrigin.y + raycastHeightOffset;

        if(!IsGrounded && !IsJumping )
        {
            if(!playerManager.IsInteracting)
            {
                animatorManager.PlayTargetAnimation("Falling", true);
            }

            CanJump = false;
            inAirTimer = inAirTimer + Time.deltaTime;
            playerRigidbody.AddForce(transform.forward * leapingVelocity);
            playerRigidbody.AddForce(-Vector3.up * fallingVelocity * inAirTimer);
        }

        if(Physics.Raycast(transform.position + Vector3.up, Vector3.down, 1.8f, groundLayer))
        {
            if (!IsGrounded)
            {
                animatorManager.PlayTargetAnimation("Landing", true);
                StartCoroutine(CooldownForJumping(1));
            }

            inAirTimer = 0;
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    }


    public void HandleJumping()
    {
        if(IsGrounded && CanJump)
        {
            animatorManager.animator.SetBool("isJumping", true);
            animatorManager.PlayTargetAnimation("Jump", false);

            float jumpingVelocity = Mathf.Sqrt(-2 * gravityIntensity * jumpHeight);
            Vector3 playerVelocity = moveDirection;
            playerVelocity.y = jumpingVelocity;
            playerRigidbody.velocity = playerVelocity;

        }
    }

    IEnumerator CooldownForJumping(int time)
    {
        yield return new WaitForSeconds(time);
        CanJump = true;
    }
}
