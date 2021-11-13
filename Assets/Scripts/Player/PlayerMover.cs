using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Player))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private PlayerCollisionHandler _playerCollisionHandler;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;
    private int _traveledDistance;
    private Player _player;


    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();

        ResetPlayer();
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
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

    public void ResetPlayer()
    {
        transform.position = _startPosition;
        _rigidbody2D.velocity = Vector2.zero;
    }

    private void AddScoreForDistanse()
    {
        _traveledDistance = (int)transform.position.x;

        _player.AddScore(_traveledDistance);
       // Debug.Log(_traveledDistance);
    }
}