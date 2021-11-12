using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectsPool
{
    [SerializeField] private GameObject[] _obstaclePrefab;
    [SerializeField] private GameObject _previousObstacle;
    [SerializeField] private Transform _spawnPoint;

    private int _minDdistanceBetweenObstacles = 1;
    private int _maxDistanceBetweenObstacles = 4;
    private int _distanceBetweenObstacles;

    private float _previousObstacleWidth;
    private float _currentObstacleWidth;

    private void Start()
    {
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
        obstacle.SetActive(true);
        obstacle.transform.position = spawnPoint;
    }
}
