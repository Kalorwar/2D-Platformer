using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IHitable, IMovable, IGroundChecker
{
    public event Action OnDie;
    
    [SerializeField] private List<RecallStone> _recallStones;
    
    private PlayerHealthUI _playerHealthUI;

    [Inject]
    private void Constructor(PlayerConfig config)
    {
        Speed = config.Speed;
        JumpForce = config.JumpForce;
        Health = config.Health;
    }
    
    [field: SerializeField] public float Health { get; private set; }
    public float Speed { get; private set; }
    public float JumpForce { get; private set; }
    public bool IsGround { get; private set; }
    public bool IsDie { get; private set; }
    public Rigidbody2D Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        _playerHealthUI = GetComponent<PlayerHealthUI>();
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<Ground>(out Ground ground))
        {
            IsGround = true;
        }

        if (collider.gameObject.TryGetComponent<RecallStone>(out RecallStone recallStone))
        {
            if(_recallStones.Contains(recallStone))
                return;
            _recallStones.Add(recallStone);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<Ground>(out Ground ground))
        {
            IsGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<DeathZone>(out DeathZone deathZone))
        {
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        if(IsDie)
            return;
        if (damage > 0)
        {
            Health -= damage;
            if (Health <= 0)
                Die();
        }
        else
        {
            throw new ArgumentException("Damage must be positive");
        }
        _playerHealthUI.HeartsCountChange();
    }

    private void Die()
    {
        IsDie = true;
        OnDie?.Invoke();
    }
}