using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemInStoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;

    private ItemInStore _itemInStore;

    public event UnityAction<ItemInStore, ItemInStoreView> SellButtonClick;

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

    private void TryLockItem()
    {
        if (_itemInStore.IsBued)
            _sellButton.interactable = false;
    }

    public void Render(ItemInStore itemInStore)
    {
        _itemInStore = itemInStore;
        _label.text = itemInStore.Label;
        _price.text = itemInStore.Price.ToString();
        _icon.sprite = itemInStore.Icon;
    }

    private void OnButtonClick()
    {
         SellButtonClick?.Invoke(_itemInStore, this);
    }
}
