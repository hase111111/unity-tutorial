using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
    [SerializeField] GameObject _orbPrefab;
    [SerializeField] float _spawnInterval = 1.0f;
    float _time = 0.0f;

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _spawnInterval)
        {
            Spawn();
            _time = 0.0f;
        }
    }

    void Spawn()
    {
        float y = Random.Range(-4.0f, 4.0f);
        bool isRight = Random.Range(0, 2) == 0;
        float angle = Random.Range(-30.0f, 30.0f);

        Vector3 pos;

        if (isRight)
        {
            pos = new Vector3(3.0f, y, 0.0f);
        }
        else
        {
            pos = new Vector3(-3.0f, y, 0.0f);
        }

        // ÉIÅ[ÉuÇê∂ê¨
        var rot = Quaternion.Euler(0.0f, 0.0f, angle);
        Instantiate(_orbPrefab, pos, rot);
    }
}
