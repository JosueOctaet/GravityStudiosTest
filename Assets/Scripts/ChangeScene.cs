using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Method for playing the game
    public void PlayGame()
    {
        // Load scene with build index 1
        SceneManager.LoadScene(1);
    }
}
