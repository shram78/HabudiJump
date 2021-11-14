using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]

public class Player : MonoBehaviour
{
    [SerializeField] private List<ItemInStore> _itemsInStore; // ренайм когда придумаешь что продается в магазе

    private ItemInStore _currentItem;//

    private PlayerMover _mover;
    // private int _score;

    public int Score { get; private set; }

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
        // _currentItem = _itemsInStore[0]; // В будущем будет у нас по другому, пока пишу магазин пусть так
        // эксепшн пока
    }


    public void ResetPlayer()
    {
        Score = 0;
        ScoreChanged?.Invoke(Score);
        _mover.ResetPlayer();
    }

    public void Die()
    {
        GameOver?.Invoke();
    }


    public void AddScore(int score)
    {
        Score = score;

        ScoreChanged?.Invoke(Score);
    }

    public void BuyItemInStore(ItemInStore itemInStore)
    {
        Score -= itemInStore.Price;
        ScoreChanged?.Invoke(Score);
        _itemsInStore.Add(itemInStore);
    }
}