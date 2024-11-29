using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSequence : MonoBehaviour
{
    BirdDeadChecker _birdDeadChecker;
    [SerializeField] GameObject _gameOverPanel;
    bool _once = false;

    void Start()
    {
        _birdDeadChecker = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdDeadChecker>();
    }


    void Update()
    {
        if (_birdDeadChecker.IsDead)
        {
            if (_once) return;

            // �R���[�`���𗘗p���āC3�b��ɃQ�[���I�[�o�[�p�l����\������
            StartCoroutine(ShowGameOverPanel());

            _once = true;
        }
    }

    IEnumerator ShowGameOverPanel()
    {
        yield return new WaitForSeconds(1.0f);
        _gameOverPanel.SetActive(true);

        //�Z�[�u�f�[�^�̓ǂݍ��݁C�l���傫���Ȃ��Ă���΍X�V
        BirdPoint birdPoint = FindObjectOfType<BirdPoint>();

        if (PlayerPrefs.GetInt("Result", 0) < birdPoint.Point)
        {
            PlayerPrefs.SetInt("Result", (int)birdPoint.Point);
        }
    }
}