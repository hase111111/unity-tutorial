using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterSpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] _playerPrefab;
    [SerializeField] public int[] _playerMoney;
    StageParameter _stageParameter;
    MoneyCounter _moneyCounter;
    readonly float _minY = -3.5f;
    readonly float _maxY = -3.0f;

    void Start()
    {
        _stageParameter = FindObjectOfType<StageParameter>();
        _moneyCounter = FindObjectOfType<MoneyCounter>();
    }

    public void SpawnPlayer(int index)
    {
        if (_playerPrefab.Length <= index || _playerMoney.Length <= index)
        {
            Debug.LogError("Invalid index");
            return;
        }

        if (_moneyCounter.Money < _playerMoney[index])
        {
            Debug.LogError("Not enough money");
            return;
        }

        Vector3 vector3 = transform.position;
        vector3.x = _stageParameter.PlayerCastlePositionX;
        vector3.y = Random.Range(_minY, _maxY);
        vector3.z = 0;
        Instantiate(_playerPrefab[index], vector3, Quaternion.identity);

        _moneyCounter.Money -= _playerMoney[index];
    }
}
