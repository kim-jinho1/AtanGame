using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Rigidbody2D _ri2;
    private Vector2 _moveDir;
    private float _speed = 5f;


    private void Awake()
    {
        _ri2 = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }
    private void Move()
    {
        float h = Input.GetAxis("Vertical");
        float v = Input.GetAxis("Horizontal");
        _moveDir = new Vector2(v, h);
        _ri2.velocity = _moveDir.normalized * _speed;
    }
}
