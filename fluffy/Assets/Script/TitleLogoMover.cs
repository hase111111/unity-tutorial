using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleLogoMover : MonoBehaviour
{
    public bool Active { get; set; } = false;

    // Update is called once per frame
    void Update()
    {
        if (!Active) return;

        transform.position += new Vector3(0, 0.05f, 0);
    }
}
