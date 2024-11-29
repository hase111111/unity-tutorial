using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RankingText : MonoBehaviour
{
    TextMeshProUGUI _text;
    int _result = 0;

    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _result = PlayerPrefs.GetInt("Result", 0);
    }

    void Update()
    {
        _text.text = $"ç≈çÇãLò^: {_result}";
    }
}
