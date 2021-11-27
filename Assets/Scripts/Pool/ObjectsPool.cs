using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject[] Prefab)
    {
        int randonmPrefab;

        for (int i = 0; i < _capacity; i++)
        {
            randonmPrefab = Random.Range(0, Prefab.Length);
            GameObject spawned = Instantiate(Prefab[randonmPrefab], _container.transform);

            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }
}