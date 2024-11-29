using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TitleButton : MonoBehaviour
{
    bool _isClicked = false;
    readonly float _eraseTime = 1.0f;
    float _timer = 0.0f;
    [SerializeField] GameObject _fadeEffect;
    Image _image;

    void Start()
    {
        _image = _fadeEffect.GetComponent<Image>();
        _image.color = new Color(1, 1, 1, 0);

        _fadeEffect.SetActive(false);
    }

    void Update()
    {
        if (_isClicked)
        {
            _timer += Time.deltaTime;
            if (_timer >= _eraseTime)
            {
                LoadGameScene();
            }

            _image.color = new Color(1, 1, 1, _timer / _eraseTime);
        }
    }

    public void OnClickStartButton()
    {
        if (_isClicked) return;
        _isClicked = true;

        _fadeEffect.SetActive(true);
    }

    void LoadGameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}
