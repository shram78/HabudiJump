using UnityEngine;

public abstract class Boost : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBued = false;

    public string Label => _label;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBued => _isBued;

    public void Buy()
    {
        _isBued = true;
    }

    public abstract int GetPower();
}