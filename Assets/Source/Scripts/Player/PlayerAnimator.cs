using System;
using UnityEngine;
using Zenject;

public class PlayerAnimator : MonoBehaviour
{
   private Animator _animator;
   private SpriteRenderer _spriteRenderer;
   private float _velocity;
   private Player _player;
   private IInput _input;
   private LevelStateMachine _levelStateMachine;

   [Inject]
   private void Constructor(IInput input, LevelStateMachine levelStateMachine)
   {
      _input = input;
      _levelStateMachine = levelStateMachine;
   }

   private void Awake()
   {
      _animator = GetComponent<Animator>();
      _spriteRenderer = GetComponent<SpriteRenderer>();
      _player = GetComponent<Player>();
   }

   private void OnEnable()
   {
      _input.OnClickRight += ClickRight;
      _input.OnClickLeft += ClickLeft;
      _input.OnClickUp += Jump;
      _input.OnButtonUp += ButtonUp;
      _levelStateMachine.OnStateChange += LevelStateHandle;
   }

   private void OnDisable()
   {
      _input.OnClickRight -= ClickRight;
      _input.OnClickLeft -= ClickLeft;
      _input.OnClickUp -= Jump;
      _input.OnButtonUp -= ButtonUp;
      _levelStateMachine.OnStateChange += LevelStateHandle;
   }

   private void Update()
   {
      Falling();
      GroundCheck();
   }

   private void LevelStateHandle(LevelState state)
   {
      if (state == LevelState.Resurrection || state == LevelState.Fail)
         Die();
      if(state == LevelState.Game)
         Resurrection();
      if(state == LevelState.Finish)
         Rest();
      if(state ==LevelState.Pause)
         ButtonUp();
   }

   private void ClickRight()
   {
      if (_levelStateMachine.CurrenLevelState == LevelState.Game)
      {
         _spriteRenderer.flipX = false;
         _velocity = 1;
         _velocity = Math.Clamp(_velocity, 0, 1);
         _animator.SetFloat(AssetsPath.AnimationPath.Velocity, _velocity);
      }
   }

   private void ClickLeft()
   {
      if (_levelStateMachine.CurrenLevelState == LevelState.Game)
      {
         _spriteRenderer.flipX = true;
         _velocity = 1;
         _velocity = Math.Clamp(_velocity, 0, 1);
         _animator.SetFloat(AssetsPath.AnimationPath.Velocity, _velocity);
      }
   }
   
   private void GroundCheck()
   {
      if(_player.IsGround)
         _animator.SetBool(AssetsPath.AnimationPath.OnClickUp, false);
   }

   private void ButtonUp()
   {
      _velocity = 0;
      _animator.SetFloat(AssetsPath.AnimationPath.Velocity, _velocity);
   }

   private void Resurrection()
   {
      _animator.SetBool(AssetsPath.AnimationPath.OnDie, false);
   }

   private void Die()
   {
      _animator.SetBool(AssetsPath.AnimationPath.OnDie, true);
   }

   private void Rest()
   {
      _animator.SetBool(AssetsPath.AnimationPath.IsRest, true);
   }

   private void Falling()
   {
      if (!_player.IsGround)
         _animator.SetBool(AssetsPath.AnimationPath.IsFalling, true);
      else
      {
         _animator.SetBool(AssetsPath.AnimationPath.IsFalling, false);
      }
   }

   private void Jump()
   {
      if (_levelStateMachine.CurrenLevelState == LevelState.Game) 
         _animator.SetBool(AssetsPath.AnimationPath.OnClickUp, true);
   }
}