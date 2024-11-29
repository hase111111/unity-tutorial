using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageParameter : MonoBehaviour
{
    public float PlayerCastlePositionX { get; set; } = 7.0f;

    public float EnemyCastlePositionX { get; set; } = -7.0f;

    public readonly float CastlePositionY = -0.75f;
}
