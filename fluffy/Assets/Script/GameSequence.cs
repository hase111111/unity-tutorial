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
            // Playerがアクティブでなくなったらゲームオーバー
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
                // シーンをリロード
                UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
            }
        }
    }

    void ChangeToGame()
    {
        _state = State.Game;

        // PlayerTag がついているオブジェクトを取得
        var playerController = _player.GetComponent<PlayerController>();
        playerController.JumpY = -5.5f;

        // OrbSpawner をインスタンス化
        Instantiate(_spawner);

        // TitleLogoMover をアクティブにする
        var titleLogoMover = _titleLogo.GetComponent<TitleLogoMover>();
        titleLogoMover.Active = true;
    }
}
