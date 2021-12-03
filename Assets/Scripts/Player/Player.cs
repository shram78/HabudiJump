using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private List<ItemInStore> _itemsInStore; // ренайм когда придумаешь что продаетс€ в магазе
    [SerializeField] private AudioSource _dieSound;

    private ItemInStore _currentItem;//

    public int Score { get; private set; }

    public event UnityAction BeforeDie;
    public event UnityAction GameOver;

    public void Die()
    {
        BeforeDie?.Invoke();
        StartCoroutine(DelayDie());
    }

    private IEnumerator DelayDie()//
    {
        _dieSound.Play();
        while (_dieSound.isPlaying)
            yield return null;

        GameOver?.Invoke();
    }
}