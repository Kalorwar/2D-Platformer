using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelCell : MonoBehaviour
{
    private Button _button;
    private LevelData _levelData;
    private SceneService _sceneService;
}