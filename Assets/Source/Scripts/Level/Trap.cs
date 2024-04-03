using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private float _damage = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.TakeDamage(_damage);
        }
    }
}
