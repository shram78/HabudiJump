using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _cameraSpeed;

    private Vector3 _startPosition;

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
        _startPosition = transform.position;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x + (_cameraSpeed * Time.deltaTime), transform.position.y, transform.position.z);

        if (_player.transform.localPosition.x >= transform.localPosition.x)
            transform.position = new Vector3(_player.transform.localPosition.x, transform.position.y, transform.position.z);
    }

    private void ResetPosition()
    {
        transform.position = _startPosition;
    }
}