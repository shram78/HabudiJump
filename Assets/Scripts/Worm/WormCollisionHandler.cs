using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Worm))]

public class WormCollisionHandler : MonoBehaviour
{
    private Worm _bird;

    public event UnityAction StayOnJumpPlatform;

    private void Start()
    {
        _bird = GetComponent<Worm>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out JumpPlatform jumpPlatform))
        {
            StayOnJumpPlatform?.Invoke();
        }

        else if (collision.TryGetComponent(out ScoreZone scoreZone))
        {
            _bird.IncreaseScore();
        }
        else
        {
            //  _bird.Die();
            Debug.Log("KILLL");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out MovingPlatform movingPlatform))
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out MovingPlatform movingPlatform))
        {
            this.transform.parent = null;
        }
    }
}