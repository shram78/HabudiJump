using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectsPool
{
    [SerializeField] private GameObject[] _obstaclePrefab;
    [SerializeField] private GameObject _previousObstacle;
    [SerializeField] private Transform _spawnPoint;

    private Vector3 _startPosition;
    private float _minDdistanceBetweenObstacles = 1.5f;
    private float _maxDistanceBetweenObstacles = 3.5f;
    private float _distanceBetweenObstacles;

    private float _previousObstacleWidth;
    private float _currentObstacleWidth;

    private void Start()
    {
        _startPosition = transform.position;
        Initialize(_obstaclePrefab);
    }

    private void Update()
    {
        if (transform.position.x < _spawnPoint.position.x)
        {
            if (TryGetObject(out GameObject obstacles))
            {
                GetSizeObstacles(obstacles);

                transform.position = new Vector3(transform.position.x + (_previousObstacleWidth / 2 + _currentObstacleWidth / 2) + _distanceBetweenObstacles, transform.position.y, transform.position.z);

                SetObstacle(obstacles, transform.position);

                _previousObstacle = obstacles;
            }
        }
    }

    private void GetSizeObstacles(GameObject obstacles)
    {
        _previousObstacleWidth = _previousObstacle.transform.localScale.x;
        _currentObstacleWidth = obstacles.transform.localScale.x;
        _distanceBetweenObstacles = Random.Range(_minDdistanceBetweenObstacles, _maxDistanceBetweenObstacles);
    }

    private void SetObstacle(GameObject obstacle, Vector3 spawnPoint)
    {
        obstacle.GetComponent<Rigidbody2D>().isKinematic = true;

        obstacle.SetActive(true);
        obstacle.transform.position = spawnPoint;
    }

    public void ResetPosition()
    {
        transform.position = _startPosition;
    }
}
