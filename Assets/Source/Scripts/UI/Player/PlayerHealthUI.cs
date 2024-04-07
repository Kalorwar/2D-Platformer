using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private List <Image> _hearts;
    [SerializeField] private Sprite _fullHeart;
    [SerializeField] private Sprite _emptyHeart;
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    public void HeartsCountChange()
    {
        for (int i = 0; i < _hearts.Count; i++)
        {
            if (i < Math.Round(_player.Health))
            {
                _hearts[i].sprite = _fullHeart;
            }
            else
            {
                _hearts[i].sprite = _emptyHeart;
            }
        }
    }
}
