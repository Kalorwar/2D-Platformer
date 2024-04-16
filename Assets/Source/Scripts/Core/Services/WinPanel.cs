using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class WinPanel : MonoBehaviour
{
    private SceneService _sceneService;

    [Inject]
    private void Constructor(SceneService sceneService)
    {
        _sceneService = sceneService;
    }

    public void Restart()
    {
        _sceneService.Restart();
    }
    
    public void LoadMenu()
    {
        _sceneService.LoadScene("Scenes/MeinMenu");
    }

    public void LoadNextLevel()
    {
        _sceneService.LoadNextScene();
    }
}