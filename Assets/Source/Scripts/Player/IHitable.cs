public interface IHitable
{
    public bool IsDie { get; }
    public float Health { get; }
    public void TakeDamage(float damage);
}