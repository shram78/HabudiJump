using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform _groundChecker;

    private float _speed = 2;
    private float _distanceDetectionGround = 1;
    private bool _movingRight;
    private RaycastHit2D _groundInfo;

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);

         _groundInfo = Physics2D.Raycast(_groundChecker.position, Vector2.down, _distanceDetectionGround);

        if (_groundInfo.collider == false)
        {
            if (_movingRight)
            {
                transform.eulerAngles = new Vector2(0, 180);
                _movingRight = false;
            }

            else
            {
                transform.eulerAngles = new Vector3(0, 0);
                _movingRight = true;
            }
        }
    }
}
