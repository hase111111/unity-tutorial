using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroyer : MonoBehaviour
{
    BirdPoint _birdPoint;

    void Start()
    {
        _birdPoint = FindObjectOfType<BirdPoint>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            // 親オブジェクトを破壊する
            Destroy(other.gameObject);

            // ポイントを加算する
            _birdPoint.Point += 0.25f;
        }
    }
}
