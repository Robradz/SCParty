using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadMove : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] private string horizontalInputName;
    [SerializeField] private string vertticalInputName;

    [SerializeField] private float movementSpeed;
    float forwardAmount;
    //[SerializeField] private float sprintMultiplier = 1f;

    private CharacterController charController;
    GamepadLook lookScript;

    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private KeyCode jumpKey;
    float jumpForce;

    private bool isJumping = false;
    private bool onGround = true;

    Vector2 i_movement;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        lookScript = GetComponent<GamepadLook>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        UpdateAnimator();
    }

    private void OnMove(InputValue value)
    {
        i_movement = value.Get<Vector2>();
    }

    private void PlayerMovement()
    {
        float vertInput = i_movement.y * movementSpeed;
        float horizInput = i_movement.x * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        forwardAmount = Math.Abs(forwardMovement.z);

        charController.SimpleMove((forwardMovement + rightMovement)); // Accounts for Time.deltaTime
    }

    private void OnJumpPS2() { JumpInput(); }
    private void OnJumpXbox() { JumpInput(); }

    private void JumpInput()
    {
        if (!isJumping)
        {
            isJumping = true;
            print("Jump");
            StartCoroutine(JumpEvent());
        }
    }

    private IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90f;
        float timeInAir = 0.0f;

        do
        {
            jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45f;
        isJumping = false;
    }

    private void UpdateAnimator()
    {
        float turnAmount = lookScript.turnAmount;
        animator.SetFloat("Forward", forwardAmount, 0.1f, Time.deltaTime);
        animator.SetFloat("Turn", turnAmount, 0.1f, Time.deltaTime);
        animator.SetBool("OnGround", !isJumping);
        if (!charController.isGrounded)
        {
            animator.SetFloat("Jump", jumpForce);
        }
    }

}
