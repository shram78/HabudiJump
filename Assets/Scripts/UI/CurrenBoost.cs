using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class CurrenBoost : MonoBehaviour
{
    [SerializeField] private Player _player;
    private Image _icon;

    private void Start()
    {
        _icon = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _player.BoostChanged += ShowCurrent;
    }

    private void OnDisable()
    {
        _player.BoostChanged -= ShowCurrent;
    }

    private void ShowCurrent(Boost boost)
    {
        _icon.sprite = boost.Icon;
    }
}
