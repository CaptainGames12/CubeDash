
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UnityEvent loadSave;
    public PlayerMovement player;
    
    public GameObject completeScreen;
    public float restartDelay;
    bool isGameEnded = false;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "BlankLevel")
        {
            loadSave.Invoke();
            
        }
            
    }
    public void EndGame()
    {
        if (!isGameEnded)
        {
            isGameEnded = true;
            Debug.Log("Game over");
            Invoke(nameof(Restart), restartDelay);
        }

    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void CompleteLevel()
    {
        player.enabled = false;
        
        completeScreen.SetActive(true);
    }
}
