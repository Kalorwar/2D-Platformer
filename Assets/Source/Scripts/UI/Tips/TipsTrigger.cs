using System;
using UnityEngine;

public class TipsTrigger : MonoBehaviour
{
    [SerializeField] private string _message;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<Player>(out Player player))
        {
           TipsAnimator.OnTriggerEnter?.Invoke(_message);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<Player>(out Player player))
        {
            TipsAnimator.OnTriggerExit?.Invoke();
        }
    }
}