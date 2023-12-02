using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Animator playerAnimator;
    private InputManager inputManager;
    private PlayerLocomotion playerLocomotion;

    public bool isInteracting;
    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        inputManager.HandleAllInputs();
    }

    private void FixedUpdate()
    {
        playerLocomotion.HandleAllMovement();
    }

    private void LateUpdate()
    {
        playerLocomotion.isJumping = playerAnimator.GetBool("isJumping");

        isInteracting = playerAnimator.GetBool("isInteracting");
    }
}
