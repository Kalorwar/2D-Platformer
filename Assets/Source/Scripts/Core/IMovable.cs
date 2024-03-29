using UnityEngine;

public interface IMovable
{
    public float Speed { get; }
    public float JumpForce { get; }
    public Rigidbody2D Rigidbody { get; }
}