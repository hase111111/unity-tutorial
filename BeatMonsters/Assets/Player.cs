using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _coinLabel;
    [SerializeField] TextMeshProUGUI _levelLabel;
    [SerializeField] Button _levelUpButton;
    [SerializeField] TextMeshProUGUI _levelUpCostLabel;

    int _coin = 0;
    int _level = 1;
    public int KillCount { get; set; } = 0;

    readonly EntityLevelUp _entityLevelUp = new EntityLevelUp();

    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();

        LoadData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateUI()
    {
        _coinLabel.text = $"Coin : {_coin}";
        _levelLabel.text = $"Level : {_level}";
        _levelUpCostLabel.text = $"Coin : {_entityLevelUp.GetCoin(_level)}";

        // コインが足りているかどうかでボタンのインタラクティブを変更
        int coin = _entityLevelUp.GetCoin(_level);
        _levelUpButton.interactable = (_coin >= coin);
    }

    public void OnLevelUp()
    {
        Debug.Log("Level Up");

        int coin = _entityLevelUp.GetCoin(_level);
        if (_coin >= coin)
        {
            _coin -= coin;
            _level += 1;

            UpdateUI();
        }

        SaveData();
    }

    public void OnKillMonster()
    {
        Debug.Log("Kill Monster");

        int coin = _entityLevelUp.GetCoin(KillCount);
        _coin += coin;

        UpdateUI();

        SaveData();
    }

    public int GetPower()
    {
        // level に応じて攻撃力を返す
        return _entityLevelUp.GetPower(_level);
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Coin", _coin);
        PlayerPrefs.SetInt("Level", _level);
        PlayerPrefs.SetInt("KillCount", KillCount);
    }

    public void LoadData()
    {
        _coin = PlayerPrefs.GetInt("Coin", 0);
        _level = PlayerPrefs.GetInt("Level", 1);
        KillCount = PlayerPrefs.GetInt("KillCount", 0);

        UpdateUI();
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();

        // シーンを再読み込み
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}
