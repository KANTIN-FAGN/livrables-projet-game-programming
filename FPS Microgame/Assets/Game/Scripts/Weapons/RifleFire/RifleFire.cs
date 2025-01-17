using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RifleFire : MonoBehaviour
{
    [Header("Sound Configuration")] [SerializeField]
    private AudioSource gunFire;

    [SerializeField] private GameObject handgun;
    [SerializeField] private bool canFire;

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
            gunFire.Play();
        }

        if (canFire)
        {
            canFire = false; 
            StartCoroutine(FiringBullet()); 
        }
    }

    IEnumerator FiringBullet()
    {
        Animator animator = handgun.GetComponent<Animator>();

        if (animator != null) // Vérifie si l'Animator existe
        {
            animator.SetTrigger("RifleFire");
        }
        else
        {
            Debug.LogWarning("Aucun Animator trouvé sur l'objet Handgun !");
        }

        // Attendre un délai pour réactiver le tir
        yield return new WaitForSeconds(0.4f);
        canFire = true;
    }
}