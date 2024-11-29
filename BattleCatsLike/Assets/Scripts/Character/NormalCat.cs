using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCat : MonoBehaviour
{
    readonly NormalCatBehavior _behavior = new();

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(_behavior.Speed, 0, 0);
    }
}
