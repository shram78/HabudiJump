using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _inertionX;
    [SerializeField] private PlayerScore _playerScore;
    [SerializeField] private AudioSource _jumpSound;
    [SerializeField] private Player _player;
    [SerializeField] private ParticleSystem _playerDie;

    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;
    private int _traveledDistance;
    private Animator _animator;
    private const string IsJumping = "IsJumping";

    private void OnEnable()
    {
        _player.BeforeDie += OnPlayerDie;
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundChecker.position, 0.1f, _groundLayer);

        _animator.SetBool(IsJumping, false);

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
                Move();

            if (_isGrounded)
                Jump();
        }
    }

    private void OnDisable()
    {
        _player.BeforeDie -= OnPlayerDie;
    }

    private void Move()
    {
        _animator.SetBool(IsJumping, true);

        transform.Translate(Vector2.right * _speed * Time.deltaTime);

        _rigidbody2D.AddForce(new Vector2(_inertionX, 0) * Time.deltaTime, ForceMode2D.Force);
    }

    private void Jump()
    {
        _jumpSound.Play();

        _rigidbody2D.velocity = Vector2.up * _jumpForce * Time.deltaTime;

        AddScoreForDistanse();
    }

    private void AddScoreForDistanse()
    {
        _traveledDistance = (int)transform.position.x;
        _playerScore.Add(_traveledDistance);
    }

    private void OnPlayerDie()
    {
        _rigidbody2D.AddForce(new Vector2(5, 10), ForceMode2D.Impulse);

        _playerDie.Play();
    }
}