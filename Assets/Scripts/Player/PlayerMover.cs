using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private PlayerScore _playerScore;
    [SerializeField] private Player _player;

    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;
    private int _traveledDistance;

    private void OnEnable()
    {
        _player.GameOver += ResetPosition;
    }

    private void OnDisable()
    {
        _player.GameOver -= ResetPosition;
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
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

    public void ResetPosition()
    {
        transform.position = _startPosition;
        _rigidbody2D.velocity = Vector2.zero;
    }

    private void AddScoreForDistanse()
    {
        _traveledDistance = (int)transform.position.x;
        _playerScore.AddScore(_traveledDistance);
    }
}