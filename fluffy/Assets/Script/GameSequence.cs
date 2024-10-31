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
        // 最初のフェードを実行
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
            // Playerがアクティブでなくなったらゲームオーバー
            if (!_player.activeSelf)
            {
                _state = State.GameOver;

                Debug.Log("Game Over");
            }
        }
        else if (_state == State.GameOver)
        {
            // ゲームオーバー時のフェードを実行
            var fadeSceneLoader = _endFade.GetComponent<FadeSceneLoader>();
            fadeSceneLoader.fadeDuration = 3.0f;
            fadeSceneLoader.SetCallBack(() =>
                       {
                           // シーンをリロード
                           UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
                       });
            fadeSceneLoader.CallCoroutine();

            nowFade = true;
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
