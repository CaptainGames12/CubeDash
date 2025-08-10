using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EditBlock : MonoBehaviour
{
  
    public EditManager _editManager;
    void Awake()
    {

        if (SceneManager.GetActiveScene().name == "LevelEditor")
        {

            enabled = true;

            foreach (var obj in Resources.FindObjectsOfTypeAll<EditManager>())
            {
                _editManager = obj;
            }

        }
        
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name != "LevelEditor")
        {
            enabled = false;
        }
        LevelManager.OnSceneChanged.AddListener(DestroyBlockOnSceneChange);
        
    }
    void Update()
    {
        if (transform.position.y <= 0 && gameObject.name != "Player")
        {
            Destroy(gameObject);
        }
    }
    void OnMouseEnter()
    {

        _editManager.chosenBlock = gameObject;

    }
    void OnMouseExit()
    {
        _editManager.chosenBlock = null;

    }
    public void DestroyBlockOnSceneChange(string nextSceneName)

    {
        if (nextSceneName != "LevelEditor")
        {
            Destroy(gameObject);
        }
    }
}
