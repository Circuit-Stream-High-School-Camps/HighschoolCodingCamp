using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInDirection : MonoBehaviour
{
    public float speed;
    public Vector2 moveDir;
    public Rigidbody2D _rb;

    void Start()
    {
        _rb.AddForce(moveDir * speed);
    }

}
