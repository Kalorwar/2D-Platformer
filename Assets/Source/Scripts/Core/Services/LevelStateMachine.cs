using System;
using UnityEngine;

public class LevelStateMachine : MonoBehaviour
{
    public Action<LevelState> OnStateChange;
  [field: SerializeField] public LevelState CurrenLevelState { get; private set; }

    private void Awake()
    {
        CurrenLevelState = LevelState.Game;
    }

    public void ChangeState(LevelState state)
    {
        if(CurrenLevelState == state)
            return;
        CurrenLevelState = state;
        OnStateChange?.Invoke(state);
    }
}

public enum LevelState
{
    Pause,
    Resume,
    Game,
    Finish,
    Fail,
    Resurrection
}