using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PinchInputTest : MonoBehaviour
{
    PinchInputHandler _pinchInputHandler;
    TextMeshPro _text;

    void Start()
    {
        _pinchInputHandler = GameObject.FindObjectOfType<PinchInputHandler>();
        _text = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        _text.text = _pinchInputHandler.GetPinchDelta().ToString();
    }
}
