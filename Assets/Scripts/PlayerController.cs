using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float rotationSpeed = 500f;
    [SerializeField] private float gravity = -9.81f;

    private float verticalVelocity = 0f;
    Quaternion targetRotation;
    CameraController cameraController;
    private CharacterController characterController;
    Animator animator;
    private Vector2 moveInput;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Awake()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!GameUIState.GameStarted || GameUIState.IsMenuOpen || GameUIState.GameOverOpen)
        {
            if (animator != null)
            {
                animator.SetFloat("moveAmount", 0, 0.2f, Time.deltaTime);
            }
            return;
        }

        if (Keyboard.current != null)
        {
            moveInput = new Vector2(
                Keyboard.current.dKey.isPressed ? 1 : Keyboard.current.aKey.isPressed ? -1 : 0,
                Keyboard.current.wKey.isPressed ? 1 : Keyboard.current.sKey.isPressed ? -1 : 0
            );
        }

        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y).normalized;

        Vector3 forward = cameraController.transform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 right = cameraController.transform.right;
        right.y = 0;
        right.Normalize();

        Vector3 moveDir = (forward * move.z + right * move.x).normalized;

        if (characterController.isGrounded)
            verticalVelocity = -1f;
        else
            verticalVelocity += gravity * Time.deltaTime;

        Vector3 moveWithGravity = moveDir * moveSpeed + Vector3.up * verticalVelocity;
        characterController.Move(moveWithGravity * Time.deltaTime);

        if (moveDir != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        if (animator != null)
        {
            animator.SetFloat("moveAmount", Mathf.Clamp01(moveDir.magnitude), 0.2f, Time.deltaTime);
        }
    }
}
