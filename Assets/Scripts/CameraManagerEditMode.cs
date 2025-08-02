using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class CameraManagerEditMode : MonoBehaviour
{
    public InputActionReference mouseMove;
    public InputActionReference mouseRotate;
    
    
    public Camera mainCamera;
    private Vector2 _input;
    [SerializeField] private MouseSensitivity mouseSensitivity;
    public CameraRotation _cameraRotation;
    [SerializeField] private CameraAngle cameraAngle;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }
    public void Update()
    {
        
        _cameraRotation.AroundY += _input.x * Time.deltaTime * mouseSensitivity.horizontal;
        _cameraRotation.AroundX += _input.y * Time.deltaTime * mouseSensitivity.vertical;
        _cameraRotation.AroundX = Mathf.Clamp(_cameraRotation.AroundX, cameraAngle.min, cameraAngle.max);
    }
    public void LateUpdate()
    {

        if (mouseMove.action.IsPressed())
        {
            Cursor.lockState = CursorLockMode.Locked;
            Vector3 cameraVelocity = (Vector3)_input * Time.deltaTime;
            cameraVelocity = transform.TransformDirection(cameraVelocity);
            transform.position += cameraVelocity;

        }
        if (mouseRotate.action.IsPressed())
        {
            Cursor.lockState = CursorLockMode.Locked;
            transform.eulerAngles = new Vector3(_cameraRotation.AroundX, _cameraRotation.AroundY, 0);
        }
        if (Mouse.current.leftButton.isPressed)
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }
    public void Look(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();

    }
    public static Vector2 ClampedMousePos()
    {
        
        return Vector2.ClampMagnitude(Mouse.current.position.ReadValue(), new Vector2(Screen.width - 1, Screen.height - 1).magnitude);
    }
}
[Serializable]
public struct MouseSensitivity
{
    public float horizontal;
    public float vertical;
    
}
public struct CameraRotation
{
    public float AroundY;
    public float AroundX;
}
[Serializable]
public struct CameraAngle
{
    public float min;
    public float max;
}