using UnityEngine;

public class TipsAnimator : PlayerTrigger
{
   [SerializeField] private Animator _animator;
    private int _activeTips;

    private void OnEnable()
    {
       PlayerEnter += TipFadeOut;
       PlayerExit += TipFadeIn;
    }

    private void OnDisable()
    {
        PlayerEnter -= TipFadeOut;
        PlayerExit -= TipFadeIn;
    }

   private void TipFadeOut()
    {
        _animator.SetInteger("State", ++_activeTips);
    }

    private void TipFadeIn()
    {
        _animator.SetInteger("State", --_activeTips);
    }
}