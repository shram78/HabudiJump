using UnityEngine;

public class ObstacleCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ObstacleKillZone destroyerObstacles))
            gameObject.SetActive(false);
    }
}
