using System;
using Cainos.PixelArtPlatformer_VillageProps;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Chest))]
public class SecretChest : MonoBehaviour
{
    private Chest _chest;

    private void Awake()
    {
        _chest = GetComponent<Chest>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
        {
            _chest.Open();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
        {
            _chest.Close();
            _chest.transform.DOScale(0, 1).OnComplete(() => Destroy(gameObject));
        }
    }
}