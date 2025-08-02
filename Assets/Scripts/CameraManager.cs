using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _offset;
    // Update is called once per frame
    
    void Update()
    {
        
        transform.position = _player.position + _offset;
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
