using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Obstacle destroyerObstacles))
            gameObject.SetActive(false);
    }
}
