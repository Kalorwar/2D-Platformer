using UnityEngine;
using Zenject;

public class PanelService : MonoBehaviour
{
    [SerializeField] private MenuPanel _menuPanel;
    private IInput _input;
    private LevelStateMachine _levelStateMachine;

    [Inject]
    private void Constructor(IInput input, LevelStateMachine levelStateMachine)
    {
        _input = input;
        _levelStateMachine = levelStateMachine;
    }

    private void OnEnable()
    {
        _input.OnButtonMenu += Open;
    }

    private void OnDisable()
    {
        _input.OnButtonMenu -= Open;
    }
    
    public void Close()
    {
        if(_levelStateMachine.CurrenLevelState == LevelState.Pause)
        {
            Debug.Log("close");
            _menuPanel.gameObject.SetActive(false);
            _levelStateMachine.ChangeState(LevelState.Game);
        }
    }

    private void Open()
    {
        if(_levelStateMachine.CurrenLevelState == LevelState.Game)
        {
            Debug.Log("Open");
            _menuPanel.gameObject.SetActive(true);
            _levelStateMachine.ChangeState(LevelState.Pause);
        }
    }
}