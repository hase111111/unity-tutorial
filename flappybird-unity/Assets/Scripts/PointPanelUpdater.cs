using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointPanelUpdater : MonoBehaviour
{
    BirdPoint _birdPoint;
    TextMeshProUGUI _text;

    void Start()
    {
        _birdPoint = FindObjectOfType<BirdPoint>();
        _text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        _text.text = $"ƒ|ƒCƒ“ƒg: {_birdPoint.Point:f0}";
    }
}
