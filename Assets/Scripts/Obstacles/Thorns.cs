using UnityEngine;
using DG.Tweening;

public class Thorns : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            player.Die();
    }
}