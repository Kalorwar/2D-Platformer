using System;

public interface IHitable
{
    public event Action OnDie;
    public bool IsDie { get; }
    public float Health { get; }
    public void TakeDamage(float damage);
}