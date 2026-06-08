using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;

public class PlayerLook : MonoBehaviour
{
    public Transform cameraHolder;

    public float mouseSensitivity = 100f;

    private InputSystem_Actions inputActions;

    private Vector2 lookInput;

    private float xRotation = 0f;

    [Header("Zoom")]
    public Transform cameraTransform;

    [Header("Look Limit")]
    public float minLookAngle = -40f;
    public float maxLookAngle = 70f;

    private CinemachineCamera cinemachineCamera;
    private CinemachineThirdPersonFollow thirdPersonFollow;

    public float zoomSpeed = 2f;
    public float minZoom = 2f;
    public float maxZoom = 8f;

    private float currentZoom = 5f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        cinemachineCamera =
            cameraTransform.GetComponent<CinemachineCamera>();

        thirdPersonFollow =
            cameraTransform.GetComponent<CinemachineThirdPersonFollow>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        lookInput = inputActions.Player.Look.ReadValue<Vector2>();

        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;

        // Xoay dọc camera
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minLookAngle, maxLookAngle);

        cameraHolder.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Xoay ngang player
        transform.Rotate(Vector3.up * mouseX);

        // Scroll chuột
        float scroll = Mouse.current.scroll.ReadValue().y;

        // Zoom camera
        thirdPersonFollow.CameraDistance -=
            scroll * 0.01f * zoomSpeed;

        // Giới hạn zoom
        thirdPersonFollow.CameraDistance = Mathf.Clamp(
            thirdPersonFollow.CameraDistance,
            minZoom,
            maxZoom
        );

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}