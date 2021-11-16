using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] private List<ItemInStore> _itemInStore;
    [SerializeField] private Player _player;
    [SerializeField] private ItemInStoreView _template;
    [SerializeField] private GameObject _itemContainer;

    private void Start()
    {
        for (int i = 0; i < _itemInStore.Count; i++)
        {
            AddItem(_itemInStore[i]);
        }
    }

    private void AddItem(ItemInStore itemInStore)
    {
        var view = Instantiate(_template, _itemContainer.transform);
        view.SellButtonClick += OnSellButtonClick;
        view.Render(itemInStore);
    }

    private void OnSellButtonClick(ItemInStore itemInStore, ItemInStoreView itemInStoreView)
    {
        TrySellItemInStore(itemInStore, itemInStoreView);
    }

    private void TrySellItemInStore(ItemInStore itemInStore, ItemInStoreView itemInStoreView)
    {
        if (itemInStore.Price <= _player.Score)
        {
           // _player.BuyItemInStore(itemInStore);
            itemInStore.Buy();
            itemInStoreView.SellButtonClick -= OnSellButtonClick;
        }
    }
}
