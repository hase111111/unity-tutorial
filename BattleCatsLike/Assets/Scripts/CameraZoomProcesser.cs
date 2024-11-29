using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomProcesser : MonoBehaviour
{
    readonly float _zoomMaxValue = 10.0f;
    readonly float _zoomMinValue = 4.5f;
    readonly float _cameraTargetPositionY = 6.0f;

    [SerializeField] Camera _camera;
    [SerializeField] float _zoomValue;
    [SerializeField] float _cameraTargetPositionX = 0.0f;

    void Start()
    {
        _zoomValue = _zoomMinValue;
    }

    void Update()
    {
        UpdateZoom();
    }

    void UpdateZoom()
    {
        _zoomValue = Mathf.Clamp(_zoomValue, _zoomMinValue, _zoomMaxValue);

        // カメラのSizeを変更
        _camera.orthographicSize = _zoomValue;

        // カメラの位置を変更
        Vector3 cameraPosition = _camera.transform.position;
        cameraPosition.x = _cameraTargetPositionX;
        cameraPosition.y = _zoomValue - _cameraTargetPositionY;
        _camera.transform.position = cameraPosition;
    }
}
