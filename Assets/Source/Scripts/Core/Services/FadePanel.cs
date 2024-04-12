using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Zenject;

public class FadePanel : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private FailPanel _failPanel;
    private Image _image;
    private IHitable _ihitable;

    [Inject]
    private void Constructor(IHitable ihitable)
    {
        _ihitable = ihitable;
    }

    private void Awake()
    {
        _image = GetComponent<Image>();
        _ihitable.OnDie += () => FadeIn();
    }

    private void OnDisable()
    {
        _ihitable.OnDie -= () => FadeIn();
    }

    public void FadeOut()
    {
        _image.DOFade(0, 0).OnComplete((() => _failPanel.gameObject.SetActive(true)));
    }
    
    public void FadeIn()
    {
        _image.DOFade(1, _duration).OnComplete((() => FadeOut()));
    }
}