
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EditMode : MonoBehaviour
{
    public List<Component> gameComponents;
    public List<GameObject> switchableEditObjects = new(3);
    public TMP_Text meters;
    public GameObject player;
    public GameObject mainCamera;
    public bool isInEditMode = false;
    private GameObject textOfButton;
    void Start()
    {

        gameComponents.Add(mainCamera.GetComponent<CameraManager>());
        gameComponents.Add(mainCamera.GetComponent<CameraManagerEditMode>());
        gameComponents.Add(player.GetComponent<PlayerMovement>());
        textOfButton = transform.GetChild(0).gameObject;
        SwitchEditMode();
    }
    public void SwitchEditMode()
    {
        
        if (!isInEditMode)
        {
            
            SwitchValues(btnName: "Exit Edit Mode", viewDistanceOfCamera: 200);
        }
        else
        {
            
            SwitchValues(btnName: "Enter Edit Mode", viewDistanceOfCamera: 60);
        }

    }
    void SwitchValues(string btnName, int viewDistanceOfCamera)
    {
        foreach(GameObject item in switchableEditObjects)
        {
            item.SetActive(!item.activeSelf);
        }
        foreach (Behaviour component in gameComponents)
        {
            component.enabled = !component.enabled;
        }
        player.transform.position = new Vector3(0, 1.6f, 0);
        meters.text = "0";
        
        textOfButton.GetComponent<TMP_Text>().text = btnName;
       
        mainCamera.GetComponent<Camera>().farClipPlane = viewDistanceOfCamera;
        isInEditMode = !isInEditMode;
        
            
    }
}
