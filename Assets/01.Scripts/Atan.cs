using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atan : MonoBehaviour
{
    private Rigidbody2D _ri2;
    private Vector2 _moveDir;
    private float _speed = 5f;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _bullet;


    private void Awake()
    {
        _ri2 = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        PlayerMove();
        PlayerRotation();
    }

    private void PlayerRotation()
    {
        Vector2 distance = _enemy.transform.position - transform.position;
        float z1 = Mathf.Atan(distance.y/distance.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z1);
        _bullet.transform.rotation = Quaternion.Euler(0, 0, z1);
        Debug.Log(z1);
    }

    private void PlayerMove()
    {
        float h = Input.GetAxis("Vertical");
        float v = Input.GetAxis("Horizontal");
        _moveDir = new Vector2(v, h);
        _ri2.velocity = _moveDir.normalized * _speed;
    }
    
}
