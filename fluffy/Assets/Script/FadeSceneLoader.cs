using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class FadeSceneLoader : MonoBehaviour
{
    public Image fadePanel;             // �t�F�[�h�p��UI�p�l���iImage�j
    public float fadeDuration = 1.0f;   // �t�F�[�h�̊����ɂ����鎞��
    [SerializeField] Color _startColor;
    [SerializeField] Color _endColor;

    Action _onFadeEnd = () => { };      // �t�F�[�h�������Ɏ��s���鏈��

    public void SetCallBack(Action onFadeEnd)
    {
        _onFadeEnd = onFadeEnd;
    }

    public void CallCoroutine()
    {
        StartCoroutine(FadeOutAndLoadScene());
    }

    public IEnumerator FadeOutAndLoadScene()
    {
        fadePanel.enabled = true;                 // �p�l����L����
        float elapsedTime = 0.0f;                 // �o�ߎ��Ԃ�������

        // �t�F�[�h�A�E�g�A�j���[�V���������s
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;                        // �o�ߎ��Ԃ𑝂₷
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);  // �t�F�[�h�̐i�s�x���v�Z
            fadePanel.color = Color.Lerp(_startColor, _endColor, t); // �p�l���̐F��ύX���ăt�F�[�h�A�E�g
            yield return null;                                     // 1�t���[���ҋ@
        }

        fadePanel.color = _endColor;  // �t�F�[�h������������ŏI�F�ɐݒ�

        // �t�F�[�h�������̏��������s
        _onFadeEnd();
    }
}
