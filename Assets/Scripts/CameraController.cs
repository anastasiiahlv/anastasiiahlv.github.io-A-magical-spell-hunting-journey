using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform followTarget;
    [SerializeField] float rotationSpeed = 0.1f;
    [SerializeField] float distance = 5;
    [SerializeField] float minVerticalAngle = -20;
    [SerializeField] float maxVerticalAngle = 45;
    [SerializeField] bool invertX;
    [SerializeField] bool invertY;
    [SerializeField] Vector2 framingOffset;

    float rotationX;
    float rotationY;
    float invertXVal;
    float invertYVal;

    private void Start()
    {
 
    }

    private void LateUpdate()
    {
        if (!GameUIState.GameStarted || GameUIState.IsMenuOpen || GameUIState.GameOverOpen) return;

        if (Mouse.current != null)
        {
            invertXVal = (invertX) ? -1 : 1;
            invertYVal = (invertY) ? -1 : 1;

            rotationX += Mouse.current.delta.y.ReadValue() * invertYVal * rotationSpeed;
            rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle);
            rotationY += Mouse.current.delta.x.ReadValue() * invertXVal * rotationSpeed;

            var targetRotation = Quaternion.Euler(rotationX, rotationY, 0);

            Vector3 focusPosition = followTarget.position
                + followTarget.right * framingOffset.x
                + followTarget.up * framingOffset.y;

            transform.position = focusPosition - targetRotation * new Vector3(0, 0, distance);
            transform.rotation = targetRotation;
        }
    }
}
