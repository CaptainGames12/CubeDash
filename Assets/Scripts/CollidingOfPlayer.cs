
using UnityEngine;

public class CollidingOfPlayer : MonoBehaviour
{
    private EditMode? _editMode;
    [SerializeField] private AudioSource _bumpSound;
    [SerializeField] private PlayerMovement _movementScript;
    void Start()
    {
        _editMode = FindObjectOfType<EditMode>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacles"))
        {
            if (_editMode != null)
            {
                if (_editMode.isInEditMode)
                {
                    return;
                }
            }
            _bumpSound.Play();
            _movementScript.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
