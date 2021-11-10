using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectsPool
{
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private Transform _spawnPoint; //��� []

    private void Start()
    {
        Initialize(_obstaclePrefab); // ���� �������� ������ �������
    }

    private void Update()
    {
        if (transform.position.x < _spawnPoint.position.x)
        {
            if (TryGetObject(out GameObject obstacles))
            {
                transform.position = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
                SetObstacle(obstacles, transform.position);
            }
        }
    }

    private void SetObstacle(GameObject obstacle, Vector3 spawnPoint) // ���� �������� ������ ����������
    {
        obstacle.SetActive(true);

        // spawnPoint.x = 10;

        obstacle.transform.position = spawnPoint;
    }
}
