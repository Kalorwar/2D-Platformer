using System;
using UnityEngine;

public class MovementHandler : IDisposable
{
    private IInput _input;
    private IMovable _movable;
    private IGroundChecker _groundChecker;

    public MovementHandler(IInput input, IMovable movable, IGroundChecker groundChecker)
    {
        _input = input;
        _movable = movable;
        _groundChecker = groundChecker;
        
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
        Debug.Log("Right");
        _movable.Rigidbody.velocity = new Vector2(1 * _movable.Speed, _movable.Rigidbody.velocity.y);
    }
    
    private void ClickLeft()
    {
        Debug.Log("left");
        _movable.Rigidbody.velocity = new Vector2(-1 * _movable.Speed, _movable.Rigidbody.velocity.y);
    }

    private void ClickUp()
    {
        Debug.Log("Up");
        if (_groundChecker.IsGround)
            _movable.Rigidbody.velocity = new Vector2(_movable.Rigidbody.velocity.x, 1 * _movable.JumpForce);
    }
}