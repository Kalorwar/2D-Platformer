using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IHitable, IMovable, IGroundChecker
{
    [SerializeField] private float _health;
    private float _maxHealth;

    [Inject]
    private void Constructor(PlayerConfig config)
    {
        Speed = config.Speed;
        JumpForce = config.JumpForce;
        _health = config.Health;
    }
    
    public float Speed { get; private set; }
    public float JumpForce { get; private set; }
    public bool IsGround { get; private set; }
    public bool IsDie { get; private set; }
    public Rigidbody2D Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _maxHealth = _health;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<Ground>(out Ground ground))
        {
            IsGround = true;
        }

        if (collider.TryGetComponent<DeathZone>(out DeathZone deathZone))
        {
            Die();
        }
    }
    
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<Ground>(out Ground ground))
        {
            IsGround = false;
        }
    }

    public void TakeDamage(float damage)
    {
        if(IsDie)
            return;
        if (damage > 0)
        {
            _health -= damage;
            if (_health <= 0)
                Die();
        }
        else
        {
            throw new ArgumentException("Damage must be positive");
        }
    }

    private void Die()
    {
        IsDie = true;
    }
}