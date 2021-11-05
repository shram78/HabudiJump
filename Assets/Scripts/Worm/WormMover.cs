using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class WormMover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private WormCollisionHandler _wormCollision;

    private Vector3 _finishPosition;
    private float _speed;
    private float _tapForce;
    private int _countJump;
    private Rigidbody2D _rigidbody2D;

    private void OnEnable()
    {
        _wormCollision.StayOnJumpPlatform += OnWormStayJumpPlatform;
    }

    private void OnDisable()
    {
        _wormCollision.StayOnJumpPlatform -= OnWormStayJumpPlatform;
    }


    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _speed = 4;
        _tapForce = 3;
        _countJump = 5;

        ResetWorm();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _countJump > 0)
        {
            _rigidbody2D.velocity = new Vector2(_speed, 0);
            _rigidbody2D.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
            _countJump--;
        }
    }

    private void FixedUpdate()
    {
        if (_rigidbody2D.velocity.x < 0 )
        {
            Debug.Log("Game Over");
        }
    }

    private void OnWormStayJumpPlatform()
    {
        _speed = 10;
        _tapForce = 350;
    }

    public void ResetWorm()
    {
        transform.position = _startPosition;
        _rigidbody2D.velocity = Vector2.zero;
    }
}