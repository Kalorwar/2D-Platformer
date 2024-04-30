using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private float _damage = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.TakeDamage(_damage);
            player.Rigidbody.AddForce((player.transform.position - transform.position) * 3, ForceMode2D.Impulse);
        }
    }
}
