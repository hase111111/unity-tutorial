using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField] GameObject _wallPrefab;
    [SerializeField] float _spawnInterval = 2.0f;

    BirdDeadChecker _birdDeadChecker;

    float _timer = 0.0f;
    readonly float _spawnPositionX = 2.0f;
    readonly float _spawnPositionYMim = -1.4f;
    readonly float _spawnPositionYMax = 1.4f;

    private void Start()
    {
        _birdDeadChecker = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdDeadChecker>();
    }

    void Update()
    {
        if (_birdDeadChecker.IsDead) return;

        _timer += Time.deltaTime;
        if (_timer >= _spawnInterval)
        {
            _timer = 0.0f;
            SpawnWall();
        }
    }

    void SpawnWall()
    {
        float randomY = Random.Range(_spawnPositionYMim, _spawnPositionYMax);
        Instantiate(_wallPrefab, new Vector3(_spawnPositionX, randomY, 0), Quaternion.identity);
    }
}
