using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _cameraSpeed;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x + (_cameraSpeed * Time.deltaTime), transform.position.y, transform.position.z);

        if (_player.transform.localPosition.x >= transform.localPosition.x)
            transform.position = new Vector3(_player.transform.localPosition.x, transform.position.y, transform.position.z);
    }
}