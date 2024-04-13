using System;
using UnityEngine;

public class MovementHandler : IDisposable
{
    private IInput _input;
    private IMovable _movable;
    private IGroundChecker _groundChecker;
    private LevelStateMachine _levelStateMachine;

    public MovementHandler(IInput input, IMovable movable, IGroundChecker groundChecker, LevelStateMachine levelStateMachine)
    {
        _input = input;
        _movable = movable;
        _groundChecker = groundChecker;
        _levelStateMachine = levelStateMachine;
        
        Debug.Log(input.GetType());
        Debug.Log(movable.Speed);
        
        _input.OnClickUp += ClickUp;
        _input.OnClickLeft += ClickLeft;
        _input.OnClickRight += ClickRight;
    }

    public void Dispose()
    {
        Debug.Log("отписка");
        _input.OnClickUp -= ClickUp;
        _input.OnClickLeft -= ClickLeft;
        _input.OnClickRight -= ClickRight;
    }

    private void ClickRight()
    {
        if (_levelStateMachine.CurrenLevelState == LevelState.Game)
            _movable.Rigidbody.velocity = new Vector2(1 * _movable.Speed, _movable.Rigidbody.velocity.y);
    }
    
    private void ClickLeft()
    {
        if (_levelStateMachine.CurrenLevelState == LevelState.Game)
            _movable.Rigidbody.velocity = new Vector2(-1 * _movable.Speed, _movable.Rigidbody.velocity.y);
    }

    private void ClickUp()
    {
        Debug.Log("Up");
        if (_groundChecker.IsGround && _levelStateMachine.CurrenLevelState == LevelState.Game)
            _movable.Rigidbody.velocity = new Vector2(_movable.Rigidbody.velocity.x, 1 * _movable.JumpForce);
    }
}