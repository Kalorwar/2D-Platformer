using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IHitable, IMovable, IGroundChecker
{
    [SerializeField] private List<RecallStone> _recallStones;
    
    private PlayerHealthUI _playerHealthUI;
    private LevelStateMachine _levelStateMachine;
    private PlayerConfig _playerConfig;

    [Inject]
    private void Constructor(PlayerConfig config, LevelStateMachine levelStateMachine)
    {
        Speed = config.Speed;
        JumpForce = config.JumpForce;
        Health = config.Health;
        _playerConfig = config;
        _levelStateMachine = levelStateMachine;
    }
    
    [field: SerializeField] public float Health { get; private set; }
    public float Speed { get; private set; }
    public float JumpForce { get; private set; }
    public bool IsGround { get; private set; }
    public Rigidbody2D Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        _playerHealthUI = GetComponent<PlayerHealthUI>();
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        _levelStateMachine.OnStateChange += LevelStateHandle;
    }

    private void OnDisable()
    {
        _levelStateMachine.OnStateChange -= LevelStateHandle;
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

    public void Resurrection()
    {
        _levelStateMachine.ChangeState(LevelState.Game);
        int indexLastRecallStones = _recallStones.Count -1;
        RecallStone lastRecallStones = _recallStones[indexLastRecallStones];
        transform.position = new Vector2(lastRecallStones.transform.position.x, lastRecallStones.transform.position.y +1);
        Health = _playerConfig.Health;
        _playerHealthUI.HeartsCountChange();
    }

    public void TakeDamage(float damage)
    {
        if (_levelStateMachine.CurrenLevelState == LevelState.Die || _levelStateMachine.CurrenLevelState == LevelState.Fail)
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

    private void LevelStateHandle(LevelState state)
    {
        if (_levelStateMachine.CurrenLevelState == LevelState.Game)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void Die()
    {
        if (_recallStones.Count == 0)
        {
            _levelStateMachine.ChangeState(LevelState.Fail);
        }
        else
        {
            _levelStateMachine.ChangeState(LevelState.Die);
        }
    }
}