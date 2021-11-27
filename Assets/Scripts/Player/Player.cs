using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private List<ItemInStore> _itemsInStore; // ренайм когда придумаешь что продается в магазе

    private ItemInStore _currentItem;//

    public int Score { get; private set; }

    public event UnityAction GameOver; //перед релизом проверить, если нигде не используется- снести

    public void Die()
    {
        GameOver?.Invoke();
    }
}