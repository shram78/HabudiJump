using UnityEngine;

public class FeatherTrailGenerator : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
            _particleSystem.Play();
    }
}