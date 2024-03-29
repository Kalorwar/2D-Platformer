using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
   private Animator _animator;
   private SpriteRenderer _spriteRenderer;
   private float _velocity;
   private Player _player;

   private void Awake()
   {
      _animator = GetComponent<Animator>();
      _spriteRenderer = GetComponent<SpriteRenderer>();
      _player = GetComponent<Player>();
   }

   private void Update()
   {
      Jump();
      ClickLeft();
      ClickRight();
      Falling();
   }

   private void ClickRight()
   {
      if (Input.GetKey(KeyCode.D))
      {
         _spriteRenderer.flipX = false;
         _velocity = 1;
      }
      if (Input.GetKeyUp(KeyCode.D))
         _velocity = 0;
      
      _velocity = Math.Clamp(_velocity, 0, 1);
      _animator.SetFloat("Velocity", _velocity);
   }
   
   private void ClickLeft()
   {
      if (Input.GetKey(KeyCode.A))
      {
         _spriteRenderer.flipX = true;
         _velocity = 1;
      }
      if (Input.GetKeyUp(KeyCode.A))
         _velocity = 0;
      
      _velocity = Math.Clamp(_velocity, 0, 1);
      _animator.SetFloat("Velocity", _velocity);
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
      if (Input.GetKeyDown(KeyCode.W))
         _animator.SetBool("OnClickUp", true);
      if (Input.GetKeyUp(KeyCode.W))
         _animator.SetBool("OnClickUp", false);
   }
}