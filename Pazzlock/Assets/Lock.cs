using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] GameObject _effect;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        string keyColor = collision.gameObject.name.Replace("Key", "");
        string lockColor = gameObject.name.Replace("Lock", "");

        if (keyColor.Equals(lockColor)) 
        {
            Instantiate(_effect, transform.position, Quaternion.identity);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
