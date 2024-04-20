﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;
using Zenject;

public class FadePanel : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private FailPanel _failPanel;
    [SerializeField] private WinPanel _winPanel;
    private Image _image;
    private IHitable _ihitable;
    private LevelStateMachine _levelStateMachine;

    [Inject]
    private void Constructor(IHitable ihitable, LevelStateMachine levelStateMachine)
    {
        _ihitable = ihitable;
        _levelStateMachine = levelStateMachine;
    }

    private void Awake()
    {
        _image = GetComponent<Image>();
    }
    
    private void OnEnable()
    {
        _levelStateMachine.OnStateChange += LevelStateHandle;
    }

    private void OnDisable()
    {
        _levelStateMachine.OnStateChange -= LevelStateHandle;
    }
    
    private void LevelStateHandle(LevelState state)
    {
        if (state == LevelState.Fail)
        {
            FadeIn();
            StartCoroutine(PanelActiveTick(_failPanel.gameObject));
        }

        if (state == LevelState.Die)
        {
            FadeIn();
            StartCoroutine(ResurrectionTick());
        }

        if (state == LevelState.Finish)
        {
            FadeIn();
            StartCoroutine(PanelActiveTick(_winPanel.gameObject));
        }
    }

    public void FadeIn()
    {
        _image.DOFade(1, _duration).OnComplete(() => _image.DOFade(0, 0));
    }
    
    private IEnumerator ResurrectionTick()
    {
        yield return new WaitForSeconds(_duration);
        _ihitable.Resurrection();
    }

    private IEnumerator PanelActiveTick(GameObject panel)
    {
        yield return new WaitForSeconds(_duration);
        panel.gameObject.SetActive(true);
    }
}