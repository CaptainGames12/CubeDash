using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public void ExitToMenu()
    {
        SceneManager.sceneLoaded += OnMenuEntered;
        SceneManager.LoadScene("Menu");
        
    }
    public void OnMenuEntered(Scene scene, LoadSceneMode mode)
    {
        LevelManager.OnSceneChanged.Invoke(scene.name);
    }
        
    
}
