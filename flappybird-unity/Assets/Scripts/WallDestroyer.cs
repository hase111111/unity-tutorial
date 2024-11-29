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
            // �e�I�u�W�F�N�g��j�󂷂�
            Destroy(other.gameObject);

            // �|�C���g�����Z����
            _birdPoint.Point += 0.25f;
        }
    }
}
