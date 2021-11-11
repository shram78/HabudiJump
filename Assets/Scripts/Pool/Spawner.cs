using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectsPool
{
    [SerializeField] private GameObject[] _obstaclePrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private int _minDdistanceBetweenObstacles;
    [SerializeField] private int _maxDistanceBetweenObstacles;
    [SerializeField] GameObject lastPlatform1;

    private float _obstaclePreviousWidth;
    private float _obstacleWidth;


    private int _distanceBetweenObstacles;

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
                _obstaclePreviousWidth = lastPlatform1.transform.localScale.x; 
                _obstacleWidth = obstacles.transform.localScale.x; 

                transform.position = new Vector3(transform.position.x + (_obstaclePreviousWidth/2 + _obstacleWidth/2) +1, transform.position.y, transform.position.z);

                 SetObstacle(obstacles, transform.position);

                lastPlatform1 = obstacles;
            }
        }
    }

    private void SetObstacle(GameObject obstacle, Vector3 spawnPoint) 
    {
        obstacle.SetActive(true);
        obstacle.transform.position = spawnPoint;
    }
}
