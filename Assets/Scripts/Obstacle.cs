
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    
    public GameObject obstacle;
    private Transform _player;
    private EditManager editManager;
    void Start()
    {
        editManager = FindObjectOfType<EditManager>();
        _player = FindObjectOfType<PlayerMovement>().gameObject.transform;
    }
    void Update()
    {
        if (_player == null)
        {
            _player = FindObjectOfType<PlayerMovement>().gameObject.transform;
        } 
        if (_player.position.z - transform.position.z >= 30)
        {
            Destroy(obstacle);
        }
    }
    void OnMouseEnter()
    {
        
        editManager.chosenBlock = gameObject; 
    }
    void OnMouseExit()
    {
        editManager.chosenBlock = null;

    }
}
