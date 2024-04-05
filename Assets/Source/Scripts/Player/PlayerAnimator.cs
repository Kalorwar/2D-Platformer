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

   [Inject]
   private void Conscturcor(IInput input)
   {
      _input = input;
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
      _input.NotClickRight += NotClick;
      _input.NotClickLeft += NotClick;
   }

   private void OnDisable()
   {
      _input.OnClickRight -= ClickRight;
      _input.OnClickLeft -= ClickLeft;
      _input.OnClickUp -= Jump;
      _input.NotClickRight -= NotClick;
      _input.NotClickLeft -= NotClick;
   }

   private void Update()
   {
      if (!_player.IsDie)
      {
         Falling();
      }
      Die();

      if(_player.IsGround)
         _animator.SetBool("OnClickUp", false);
      
   }

   private void ClickRight()
   {
      _spriteRenderer.flipX = false; 
      _velocity = 1;
      _velocity = Math.Clamp(_velocity, 0, 1);
      _animator.SetFloat("Velocity", _velocity);
   }

   private void NotClick()
   {
      _velocity = 0;
      _animator.SetFloat("Velocity", _velocity);
   }

   private void ClickLeft()
   {
      
      _spriteRenderer.flipX = true;
      _velocity = 1;
      _velocity = Math.Clamp(_velocity, 0, 1);
      _animator.SetFloat("Velocity", _velocity);
   }

   private void Die()
   {
      if(_player.IsDie) 
         _animator.SetBool("OnDie", true);
   }

   private void Falling()
   {
      if (!_player.IsGround)
         _animator.SetBool("IsFalling", true);
      else
      {
         _animator.SetBool("IsFalling", false);
      }
   }

   private void Jump()
   {
      _animator.SetBool("OnClickUp", true);
   }
}