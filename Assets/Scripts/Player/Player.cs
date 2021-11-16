using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private List<ItemInStore> _itemsInStore; // ������ ����� ���������� ��� ��������� � ������

    private ItemInStore _currentItem;//

    public int Score { get; private set; }

    public event UnityAction GameOver;

    public void Die()
    {
        GameOver?.Invoke();
    }
}