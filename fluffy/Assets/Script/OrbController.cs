using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    private Rigidbody2D _rb;
    readonly float _speed = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        // é©ï™ÇÃépê®Ç…äÓÇ√Ç¢ÇƒåXÇØÇÈ
        var vec = Vector2.zero;
        var rot = transform.rotation.eulerAngles;
        vec.x = _speed * Mathf.Cos(rot.z * Mathf.Deg2Rad);
        vec.y = _speed * Mathf.Sin(rot.z * Mathf.Deg2Rad);
        vec.x *= (transform.position.x > 0.0f) ? -1.0f : 1.0f;

        // ÉIÅ[ÉuÇîÚÇŒÇ∑
        _rb.velocity = vec * 3.0f;
    }
}
