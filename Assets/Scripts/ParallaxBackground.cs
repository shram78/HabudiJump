using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private float _parallaxEffectMultiplier;

    private Transform _cameraTransform;
    private Vector3 _lastCameraPosition;
    private float _textureUnitSizeX;

    private void Start()
    {
        _cameraTransform = Camera.main.transform;
        _lastCameraPosition = _cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        _textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }

    private void Update()
    {
        Vector3 deltaMovement = _cameraTransform.position - _lastCameraPosition;
        transform.position += deltaMovement * _parallaxEffectMultiplier;
        _lastCameraPosition = _cameraTransform.position;

        if (_cameraTransform.position.x - transform.position.x >= _textureUnitSizeX)
        {
            transform.position = new Vector3(_cameraTransform.position.x, transform.position.y);
        }
    }
}