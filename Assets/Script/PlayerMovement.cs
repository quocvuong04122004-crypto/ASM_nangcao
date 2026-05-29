using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float sprintSpeed = 8f;

    [Header("Jump")]
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    private CharacterController controller;
    private InputSystem_Actions inputActions;
    public Transform characterModel;
    private bool isSprinting;

    private Vector2 moveInput;

    // velocity Y
    private float yVelocity;

    // Animator
    private Animator animator;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        animator = GetComponentInChildren<Animator>();

        inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputActions.Enable();

        // Event nhảy
        inputActions.Player.Jump.performed += OnJump;
    }

    private void OnDisable()
    {
        inputActions.Player.Jump.performed -= OnJump;

        inputActions.Disable();
    }

    private void Update()
    {
        // Đọc input di chuyển
        moveInput = inputActions.Player.Move.ReadValue<Vector2>();

        isSprinting =
    inputActions.Player.Sprint.IsPressed();

        Vector3 move =
    transform.right * moveInput.x +
    transform.forward * moveInput.y;

        // Rotate model theo hướng di chuyển
        Vector3 lookDirection = new Vector3(move.x, 0f, move.z);

        if (lookDirection.magnitude > 0.1f)
        {
            Quaternion targetRotation =
                Quaternion.LookRotation(lookDirection);

            characterModel.rotation = Quaternion.Slerp(
                characterModel.rotation,
                targetRotation,
                10f * Time.deltaTime
            );
        }

        // Animation Walk
        bool isWalking = moveInput.magnitude > 0.1f;

        animator.SetBool("Walk", isWalking);

        // Gravity
        if (controller.isGrounded && yVelocity < 0)
        {
            yVelocity = -2f;
        }

        yVelocity += gravity * Time.deltaTime;

        move.y = yVelocity;

        // Di chuyển
        float currentSpeed =
    isSprinting ? sprintSpeed : moveSpeed;

        controller.Move(
            move * currentSpeed * Time.deltaTime
        );
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        // Chỉ nhảy khi chạm đất
        if (controller.isGrounded)
        {
            yVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}