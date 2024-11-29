using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomProcesser : MonoBehaviour
{
    readonly float _zoomMaxValue = 10.0f;
    readonly float _zoomMinValue = 4.5f;
    readonly float _cameraTargetPositionY = 4.8f;
    readonly float _cameraFactor = 3.6f;

    [SerializeField] Camera _camera;
    [SerializeField] float _zoomValue;
    [SerializeField] float _cameraTargetPositionX = 0.0f;

    PinchInputHandler _pinchInputHandler;
    SwipeInputHandler _swipeInputHandler;

    void Start()
    {
        _zoomValue = _zoomMinValue;

        _pinchInputHandler = GameObject.FindObjectOfType<PinchInputHandler>();
        _swipeInputHandler = GameObject.FindObjectOfType<SwipeInputHandler>();
    }

    void Update()
    {
        _zoomValue += _pinchInputHandler.GetPinchDelta() * 0.01f;

        UpdateZoom();

        if (_swipeInputHandler.IsSwiping())
        {
            _cameraTargetPositionX += _swipeInputHandler.GetSwipeDelta().x * 0.01f;

            UpdatePosition();
        }
    }

    void UpdateZoom()
    {
        _zoomValue = Mathf.Clamp(_zoomValue, _zoomMinValue, _zoomMaxValue);

        // カメラのSizeを変更
        _camera.orthographicSize = _zoomValue;

        // カメラの位置を変更
        Vector3 cameraPosition = _camera.transform.position;
        cameraPosition.x = _cameraTargetPositionX;
        cameraPosition.y = _zoomValue - _cameraTargetPositionY - _cameraFactor * _zoomValue / _zoomMaxValue;
        _camera.transform.position = cameraPosition;
    }

    void UpdatePosition()
    {

    }
}
