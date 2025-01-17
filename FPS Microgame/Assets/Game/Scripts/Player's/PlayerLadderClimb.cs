using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerLadderClimb : MonoBehaviour
{
    public float climbSpeed = 5f;
    private bool isClimbing = false; 

    private IA_Player inputActions;
    private InputAction moveAction;
    
    private Rigidbody rb;

    private void Awake()
    {
        inputActions = new IA_Player();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        moveAction = inputActions.Movements.Move;
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = true;
            rb.useGravity = false;
            rb.linearVelocity = Vector3.zero;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = false;
            rb.useGravity = true;
        }
    }

    private void Update()
    {
        if (isClimbing)
        {
            Vector2 moveInput = moveAction.ReadValue<Vector2>();
            transform.Translate(Vector3.up * moveInput.y * climbSpeed * Time.deltaTime);
        }
    }
}