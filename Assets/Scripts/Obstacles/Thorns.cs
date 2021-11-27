using UnityEngine;
using DG.Tweening;

public class Thorns : MonoBehaviour
{
    private float _positionY = 0.1f;
    private float _durationMove = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            player.Die();
    }

    private void Start()
    {
        transform.DOLocalMoveY(_positionY, _durationMove).SetLoops(-1, LoopType.Yoyo);
    }
}