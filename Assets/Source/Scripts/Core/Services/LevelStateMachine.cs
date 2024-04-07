using System;
using UnityEngine;

public class LevelStateMachine : MonoBehaviour
{
    public Action<LevelState> OnStateChange;

    private LevelState _currenLevelState = LevelState.Game;

    public void ChangeState(LevelState state)
    {
        if(_currenLevelState == state)
            return;
        OnStateChange?.Invoke(state);
        _currenLevelState = state;
    }
}

public enum LevelState
{
    Pause,
    Resume,
    Game,
    Finish,
    Fail
}