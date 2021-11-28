using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _cameraSpeed;
    [SerializeField] private float _cameraSmooth;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x + (_cameraSpeed * Time.deltaTime), transform.position.y, transform.position.z);

        if (_target.transform.position.x >= transform.position.x)
            transform.position = Vector3.Lerp(transform.position, new Vector3(_target.transform.position.x, transform.position.y, transform.position.z), _cameraSmooth * Time.deltaTime);
    }
}