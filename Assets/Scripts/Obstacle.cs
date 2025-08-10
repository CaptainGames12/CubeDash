
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    
    public GameObject obstacle;
    #nullable enable
    private Transform _player;
   
    void Start()
    {
        _player = FindObjectOfType<PlayerMovement>().gameObject.transform;
    }
    void Update()
    {
        if (_player == null)
        {
            _player = FindObjectOfType<PlayerMovement>().gameObject.transform;
        } 
        if (_player?.position.z - transform.position.z >= 30)
        {
            Destroy(obstacle);
        }
    }
    
}
