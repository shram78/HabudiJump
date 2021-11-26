using UnityEngine;

public class FeatherTrailGenerator : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;

    private void Update()
    {
        if (Input.GetMouseButton(0))
            _particleSystem.Play();
    }
}
