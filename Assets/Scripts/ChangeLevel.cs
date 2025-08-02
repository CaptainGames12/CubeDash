
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeLevel : MonoBehaviour
{
    void NextLevel()
    {
        if (SceneManager.GetActiveScene().name == "BlankLevel" || SceneManager.GetActiveScene().name == "LevelEditor")
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        LevelManager.OnSceneChanged.Invoke(SceneManager.GetActiveScene().name);
    }
}
