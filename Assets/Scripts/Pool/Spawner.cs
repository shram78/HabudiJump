using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectsPool
{
    [SerializeField] private GameObject[] _obstaclePrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private int _minDdistanceBetweenObstacles;
    [SerializeField] private int _maxDistanceBetweenObstacles;

    private int _distanceBetweenObstacles;

    private void Start()
    {
        Initialize(_obstaclePrefab); 
    }

    private void Update()
    {
        _distanceBetweenObstacles = Random.Range(_minDdistanceBetweenObstacles, _maxDistanceBetweenObstacles);

        if (transform.position.x < _spawnPoint.position.x)
        {
            if (TryGetObject(out GameObject obstacles))
            {
                transform.position = new Vector3(transform.position.x + _distanceBetweenObstacles, transform.position.y, transform.position.z);

                SetObstacle(obstacles, transform.position);
            }
        }
    }

    private void SetObstacle(GameObject obstacle, Vector3 spawnPoint) 
    {
        obstacle.SetActive(true);
        obstacle.transform.position = spawnPoint;
    }
}
