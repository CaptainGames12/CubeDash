
using UnityEngine;

using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference _movementAction;
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _sidewaySpeed;
    [SerializeField] private Rigidbody _playerRb;
    void Update()
    {
        _MoveCube();
    }
    void _MoveCube()
    {
        float x_direction = _movementAction.action.ReadValue<Vector2>().x;
        float x = x_direction * _sidewaySpeed;
        float z = _forwardSpeed;
        float y = _playerRb.velocity.y;
        _playerRb.velocity = new Vector3(x, y, z);
        
        if (transform.position.y <= 0)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        
    }
}
