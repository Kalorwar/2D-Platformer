using System;
using UnityEngine;

public class RecallStone : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _glow;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Player>())
        {
            _glow.sortingOrder = 0;
        }
    }
}
