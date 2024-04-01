using System;
using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Animator))]
public class TipsAnimator : MonoBehaviour
{
    public static Action<string> OnTriggerEnter;
    public static Action OnTriggerExit;
    
    [SerializeField] private TMP_Text _messageText;
    private Animator _animator;
    private int _activeTips;

    private void OnEnable()
    {
       OnTriggerEnter += TipFadeOut;
       OnTriggerExit += TipFadeIn;
    }

    private void OnDisable()
    {
       OnTriggerEnter -= TipFadeOut;
       OnTriggerExit -= TipFadeIn;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void TipFadeOut(string message)
    {
        _messageText.text = message;
        _animator.SetInteger("State", ++_activeTips);
    }

    private void TipFadeIn()
    {
        _animator.SetInteger("State", --_activeTips);
    }
}