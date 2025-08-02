
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
