using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _cameraSpeed;
    [SerializeField] private float _cameraSmooth;

    private Animator _animator;
    private const string _isGameOver = "isGameOver";

    private void OnEnable()
    {
        _target.BeforeDie += OnCameraShake;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x + (_cameraSpeed * Time.deltaTime), transform.position.y, transform.position.z);

        if (_target.transform.position.x >= transform.position.x)
            transform.position = Vector3.Lerp(transform.position, new Vector3(_target.transform.position.x, transform.position.y, transform.position.z), _cameraSmooth * Time.deltaTime);
    }

    private void OnDisable()
    {
        _target.BeforeDie -= OnCameraShake;
    }

    private void OnCameraShake()
    {
        _animator.SetBool(_isGameOver, true);
    }
}