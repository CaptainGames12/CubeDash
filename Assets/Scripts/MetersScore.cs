
using UnityEngine;

using TMPro;
public class MetersScore : MonoBehaviour
{
    public TMP_Text scoreText;
    public Transform player;
    // Update is called once per frame
    void Update()
    {
        scoreText.text = player.position.z.ToString("0");
    }
}
