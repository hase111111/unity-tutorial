using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSequence : MonoBehaviour
{
    [SerializeField] GameObject _spawner;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _titleLogo;

    enum State
    {
        Title,
        Game,
        GameOver,
    }

    State _state = State.Title;

    // Update is called once per frame
    void Update()
    {
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
            if (Input.GetMouseButtonDown(0))
            {
                // �V�[���������[�h
                UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
            }
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
