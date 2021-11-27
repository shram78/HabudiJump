using UnityEngine;

public class ClearObstaclesByDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out DestroyerObstacles destroyerObstacles))
            gameObject.SetActive(false);
    }
}