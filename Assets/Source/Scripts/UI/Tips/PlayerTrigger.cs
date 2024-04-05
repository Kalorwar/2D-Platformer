using System;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public Action PlayerEnter;
    public Action PlayerExit;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
        {
            PlayerEnter?.Invoke();
        }
    }
    
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
        {
            PlayerExit?.Invoke();
        }
    }
}