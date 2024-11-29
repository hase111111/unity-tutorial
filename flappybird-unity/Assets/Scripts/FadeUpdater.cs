using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FadeUpdater : MonoBehaviour
{
    public UnityAction OnFadeEnd { get; set; } = () => { };

    [SerializeField] bool _firstFade = false;
    Image _fadeImage;
    Color _fadeColor;
    bool _isFading = false;

    void Start()
    {
        _fadeImage = GetComponentInChildren<Image>();

        _fadeColor = _fadeImage.color;

        Debug.Log($"_fadeColor: {_fadeColor}");

        if (_firstFade)
        {
            _fadeImage.enabled = true;
            _fadeImage.color = new Color(_fadeColor.r, _fadeColor.g, _fadeColor.b, 1);
        }
    }

    public void FadeOut(float duration)
    {
        if (_isFading) return;

        Debug.Log("FadeOut");

        StartCoroutine(FadeOutCoroutine(duration));
    }

    public void FadeIn(float duration)
    {
        if (_isFading) return;

        Debug.Log("FadeIn");

        StartCoroutine(FadeInCoroutine(duration));
    }

    IEnumerator FadeOutCoroutine(float duration)
    {
        _fadeImage.enabled = true;
        _isFading = true;
        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            _fadeImage.color = new Color(_fadeColor.r, _fadeColor.g, _fadeColor.b, time / duration);
            yield return null;
        }
        _isFading = false;

        Debug.Log("FadeOutCoroutine");

        OnFadeEnd();

        OnFadeEnd = () => { };
    }

    IEnumerator FadeInCoroutine(float duration)
    {
        _fadeImage.enabled = true;
        _isFading = true;
        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            _fadeImage.color = new Color(_fadeColor.r, _fadeColor.g, _fadeColor.b, 1 - time / duration);
            yield return null;
        }
        _isFading = false;
        _fadeImage.enabled = false;

        Debug.Log("FadeInCoroutine");

        OnFadeEnd();

        OnFadeEnd = () => { };
    }
}
