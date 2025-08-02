
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    
    public GameManager gameManager;
    void Start()
    {
       
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
