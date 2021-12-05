using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class BoostView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;

    private Boost _boost;

    public event UnityAction<Boost, BoostView> SellButtonClick;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
        _sellButton.onClick.AddListener(TryLockItem);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
        _sellButton.onClick.RemoveListener(TryLockItem);
    }

    public void Render(Boost boost)
    {
        _boost = boost;
        _label.text = boost.Label;
        _price.text = boost.Price.ToString();
        _icon.sprite = boost.Icon;
    }

    private void TryLockItem()
    {
        if (_boost.IsBued)
            _sellButton.interactable = false;
    }

    private void OnButtonClick()
    {
        SellButtonClick?.Invoke(_boost, this);
    }
}