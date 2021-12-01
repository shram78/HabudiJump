using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]

public class FallingObstacle : MonoBehaviour
{
    [SerializeField] private AudioSource _jumpSound;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _rigidbody2D.isKinematic = false;
            _jumpSound.Play();
        }
    }
}