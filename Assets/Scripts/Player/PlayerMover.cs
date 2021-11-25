using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private PlayerScore _playerScore;

    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;
    private int _traveledDistance;
    private Animator _animator;
    private const string _isJumping = "IsJumping";

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
            _animator.SetBool(_isJumping, true);
        }
        else
        {
            _animator.SetBool(_isJumping, false);
        }
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundChecker.position, 0.1f, _groundLayer);

        if (_isGrounded)
        {
            Jump();

            AddScoreForDistanse();
        }
    }

    private void Jump()
    {
        _rigidbody2D.velocity = Vector2.up * _jumpForce;
    }

    private void AddScoreForDistanse()
    {
        _traveledDistance = (int)transform.position.x;
        _playerScore.AddScore(_traveledDistance);
    }
}