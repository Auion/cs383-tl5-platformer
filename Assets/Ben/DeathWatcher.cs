using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathWatcher : MonoBehaviour
{
    [SerializeField] GameObject player; // Assign this in the Inspector
    

    void Update()
    {
        if (player == null) // If player is destroyed
        {
            
            LoadDeathScene();
        }
    }

    void LoadDeathScene()
    {
        // Ensure the scene exists before loading
        if (SceneManager.GetSceneByBuildIndex(2) != null)
        {
            
            SceneManager.LoadScene(2);
        }
        else
        {
            Debug.LogError("Scene index 3 does not exist. Check Build Settings.");
        }
    }
}

