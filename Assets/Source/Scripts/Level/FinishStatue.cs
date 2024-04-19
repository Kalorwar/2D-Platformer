using System;
using UnityEngine;
using Zenject;

public class FinishStatue : MonoBehaviour
{
    private LevelStateMachine _levelStateMachine;

    [Inject]
    private void Constructor(LevelStateMachine levelStateMachine)
    {
        _levelStateMachine = levelStateMachine;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
        {
            _levelStateMachine.ChangeState(LevelState.Finish);
        }
    }
}