using UnityEngine;
using UnityEngine.InputSystem;

public class RifleFire : MonoBehaviour
{
    [Header("Sound Configuration")] [SerializeField]
    private AudioSource gunFire; 

    private IA_RifleFire inputActions; 
    private InputAction fireAction;

    private void Awake()
    {
        inputActions = new IA_RifleFire();
    }

    private void OnEnable()
    {
        fireAction = inputActions.Sound.Fire;
        fireAction.performed += OnFire;
        fireAction.Enable();
    }

    private void OnDisable()
    {
        fireAction.Disable();
        fireAction.performed -= OnFire;
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        Fire();
    }

    private void Fire()
    {
        if (gunFire != null)
        {
            gunFire.Play(); // Jouer le son du tir
        }
    }
}