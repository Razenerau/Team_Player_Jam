using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D Rigidbody;
    public Collider2D Collider;

    [Header("Input")]
    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Left;
    public KeyCode Right;

    [Header("Variables")]
    public float SpeedSensetivity;
    public float Speed;
    public float Horizontal;
    public float Vertical;
}
