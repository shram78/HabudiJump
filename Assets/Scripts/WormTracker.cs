using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormTracker : MonoBehaviour
{
    [SerializeField] private Worm _worm;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        transform.position = new Vector3(_worm.transform.position.x - _xOffset, transform.position.y, transform.position.z);
    }
}