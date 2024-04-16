﻿using UnityEngine;
using Zenject;

public class FailPanel : MonoBehaviour
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
}