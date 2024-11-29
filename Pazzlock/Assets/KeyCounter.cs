using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCounter : MonoBehaviour
{
    int _keyNum = 0;
    PlayerMover _playerMover;

    private void Start()
    {
        _playerMover = FindObjectOfType<PlayerMover>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            _keyNum++;

            Debug.Log($"Key num is {_keyNum}");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key")) 
        {
            _keyNum--;
            Debug.Log($"Key num is {_keyNum}");
        }

        if (_keyNum == 0) 
        {
            Debug.Log($"GameClear");
            _playerMover.GameClear();
        }
    }
}
