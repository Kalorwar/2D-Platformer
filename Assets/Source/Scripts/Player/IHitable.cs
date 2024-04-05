public interface IHitable
{
    public bool IsDie { get; }
    public void TakeDamage(float damage);
}