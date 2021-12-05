using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] private List<Boost> _boosts;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerScore _playerScore;
    [SerializeField] private BoostView _template;
    [SerializeField] private GameObject _itemContainer;

    private void Start()
    {
        for (int i = 0; i < _boosts.Count; i++)
        {
            AddItem(_boosts[i]);
        }
    }

    private void AddItem(Boost boost)
    {
        var view = Instantiate(_template, _itemContainer.transform);

        view.SellButtonClick += OnSellButtonClick;

        view.Render(boost);
    }

    private void OnSellButtonClick(Boost boost, BoostView boostView)
    {
        TrySellBoost(boost, boostView);
    }

    private void TrySellBoost(Boost boost, BoostView boostView)
    {
        if (boost.Price <= _playerScore.TotalScore)
        {
            _player.BuyBoost(boost);

            boost.Buy();

            boostView.SellButtonClick -= OnSellButtonClick;
        }
    }
}
