
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OpenLevelEditor()
    {
        SceneManager.LoadScene("LevelEditor");
    }
    public void LoadCreatedLevel()
    {
        if(File.Exists(Path.Combine(Application.persistentDataPath, "level.json"))) SceneManager.LoadScene("BlankLevel");
    }
}
