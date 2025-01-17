using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControllers : MonoBehaviour
{
    [Header("Player Settings")] [SerializeField]
    private int speed = 10;

    [SerializeField] private int jumpForce = 5;

    [Header("Camera Settings")] [SerializeField]
    private Transform cameraTransform;

    [SerializeField] private float mouseSensitivity = 75f;

    private IA_Player inputActions;
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction lookAction;

    private Rigidbody rb;
    private float pitch = 0f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputActions = new IA_Player();
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        if (cameraTransform == null)
        {
            cameraTransform = Camera.main?.transform;
            if (cameraTransform == null)
            {
                Debug.LogError(
                    "Aucune caméra n'a été assignée au PlayerController, et aucune caméra principale n'est trouvée.");
            }
        }
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        moveAction = inputActions.Movements.Move;
        moveAction.Enable();

        jumpAction = inputActions.Movements.Jump;
        jumpAction.performed += OnJump;
        jumpAction.Enable();

        lookAction = inputActions.Camera.Look;
        lookAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
        lookAction.Disable();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void Update()
    {
        Vector2 lookInput = lookAction.ReadValue<Vector2>();

        float yaw = lookInput.x * mouseSensitivity * Time.deltaTime;
        pitch -= lookInput.y * mouseSensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -90f, 90f); 
        
        if (cameraTransform != null)
        {
            cameraTransform.localRotation = Quaternion.Euler(pitch, 0, 0);
        }

        transform.Rotate(Vector3.up * yaw);
    }

    private void FixedUpdate()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        
        Vector3 moveDirection = cameraTransform.forward * moveInput.y + cameraTransform.right * moveInput.x;
        moveDirection.y = 0f;

        rb.linearVelocity = new Vector3(
            moveDirection.normalized.x * speed,
            rb.linearVelocity.y, 
            moveDirection.normalized.z * speed
        );
    }
}