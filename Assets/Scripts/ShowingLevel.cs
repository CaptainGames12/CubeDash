
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowingLevel : MonoBehaviour
{
    
    public LevelManager levelManager;
    void Start()
    {
        string level;
        if (SceneManager.GetActiveScene().name == "BlankLevel" || SceneManager.GetActiveScene().name == "LevelEditor")
        {
            levelManager = FindObjectOfType<LevelManager>();
            level = levelManager.levelName;
        }
        else
        {
            level = SceneManager.GetActiveScene().buildIndex.ToString();
        }
        GetComponent<TMP_Text>().text = "LEVEL " + level + "\n<b>COMPLETE</b>";
        
    }

    
}
