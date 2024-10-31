using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSequence : MonoBehaviour
{
    [SerializeField] GameObject _spawner;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _titleLogo;
    [SerializeField] GameObject _firstFade;
    [SerializeField] GameObject _endFade;

    bool nowFade = true;

    enum State
    {
        Title,
        Game,
        GameOver,
    }

    State _state = State.Title;

    private void Start()
    {
        // �ŏ��̃t�F�[�h�����s
        var fadeSceneLoader = _firstFade.GetComponent<FadeSceneLoader>();
        fadeSceneLoader.SetCallBack(() =>
               {
                   nowFade = false;
               });
        fadeSceneLoader.CallCoroutine();
    }

    // Update is called once per frame
    void Update()
    {
        if (nowFade) return;

        if (_state == State.Title)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _state = State.Game;
                ChangeToGame();
            }
        }
        else if (_state == State.Game)
        {
            // Player���A�N�e�B�u�łȂ��Ȃ�����Q�[���I�[�o�[
            if (!_player.activeSelf)
            {
                _state = State.GameOver;

                Debug.Log("Game Over");
            }
        }
        else if (_state == State.GameOver)
        {
            // �Q�[���I�[�o�[���̃t�F�[�h�����s
            var fadeSceneLoader = _endFade.GetComponent<FadeSceneLoader>();
            fadeSceneLoader.fadeDuration = 3.0f;
            fadeSceneLoader.SetCallBack(() =>
                       {
                           // �V�[���������[�h
                           UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
                       });
            fadeSceneLoader.CallCoroutine();

            nowFade = true;
        }
    }

    void ChangeToGame()
    {
        _state = State.Game;

        // PlayerTag �����Ă���I�u�W�F�N�g���擾
        var playerController = _player.GetComponent<PlayerController>();
        playerController.JumpY = -5.5f;

        // OrbSpawner ���C���X�^���X��
        Instantiate(_spawner);

        // TitleLogoMover ���A�N�e�B�u�ɂ���
        var titleLogoMover = _titleLogo.GetComponent<TitleLogoMover>();
        titleLogoMover.Active = true;
    }
}
