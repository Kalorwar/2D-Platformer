public interface IHitable
{
    public float Health { get; }
    public void TakeDamage(float damage);
    public void Resurrection();
}