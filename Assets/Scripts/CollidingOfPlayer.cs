
using UnityEngine;

public class CollidingOfPlayer : MonoBehaviour
{
    
    [SerializeField] private PlayerMovement _movementScript;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacles")
        {
            _movementScript.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
