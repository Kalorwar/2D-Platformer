using UnityEngine;
using UnityEngine.SceneManagement;

public class FailPanel : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Scenes/MeinMenu");
    }
}