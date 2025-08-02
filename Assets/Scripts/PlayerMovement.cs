
using UnityEngine;

using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference _movementAction;
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _sidewaySpeed;
    [SerializeField] private Rigidbody _playerRb;
    void FixedUpdate()
    {
        _MoveCube();
    }
    void _MoveCube()
    {
        float x_direction = _movementAction.action.ReadValue<Vector2>().x;
        float x = x_direction * _sidewaySpeed;
        float z = _forwardSpeed * Time.deltaTime;
        _playerRb.AddForce(0, 0, z);
        _playerRb.AddForce(x, 0, 0, ForceMode.VelocityChange);
        if (transform.position.y <= 0)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        
    }
}
