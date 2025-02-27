using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathWatcher : MonoBehaviour
{
    void Update()
    {
        PlayerScript player = FindAnyObjectByType<PlayerScript>();
        if (player.gameOver)
        {
            SceneManager.LoadScene(2);
        }

    }
}
