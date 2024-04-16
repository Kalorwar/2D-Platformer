using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneService : MonoBehaviour
{
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void Restart()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}