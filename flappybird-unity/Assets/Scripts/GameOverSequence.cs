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

            // コルーチンを利用して，3秒後にゲームオーバーパネルを表示する
            StartCoroutine(ShowGameOverPanel());

            _once = true;
        }
    }

    IEnumerator ShowGameOverPanel()
    {
        yield return new WaitForSeconds(1.0f);
        _gameOverPanel.SetActive(true);

        //セーブデータの読み込み，値が大きくなっていれば更新
        BirdPoint birdPoint = FindObjectOfType<BirdPoint>();

        if (PlayerPrefs.GetInt("Result", 0) < birdPoint.Point)
        {
            PlayerPrefs.SetInt("Result", (int)birdPoint.Point);
        }
    }
}