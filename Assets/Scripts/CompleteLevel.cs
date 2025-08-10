
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    
    public GameManager gameManager;
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "LevelEditor")
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
        gameManager = FindObjectOfType<GameManager>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.CompleteLevel();
        }

    }
    
}
