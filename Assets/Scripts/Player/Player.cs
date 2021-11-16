using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private List<ItemInStore> _itemsInStore; // ренайм когда придумаешь что продаетс€ в магазе

    private ItemInStore _currentItem;//

    public int Score { get; private set; }

    public event UnityAction GameOver;

    public void Die()
    {
        GameOver?.Invoke();
    }
}