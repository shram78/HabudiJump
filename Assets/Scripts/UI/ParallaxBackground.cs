using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private float _parallaxEffectMultiplier;

    private Transform _cameraTransform;
    private Vector3 _lastCameraPosition;
    private float _textureUnitSizeX;

    private void Start()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;

        _cameraTransform = Camera.main.transform;
        _lastCameraPosition = _cameraTransform.position;

        Texture2D texture = sprite.texture;
        _textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }

    private void Update()
    {
        Vector3 deltaMovement = _cameraTransform.position - _lastCameraPosition;
        transform.position += deltaMovement * _parallaxEffectMultiplier;
        _lastCameraPosition = _cameraTransform.position;

        if (_cameraTransform.position.x - transform.position.x >= _textureUnitSizeX)
            transform.position = new Vector3(_cameraTransform.position.x, transform.position.y);
    }
}