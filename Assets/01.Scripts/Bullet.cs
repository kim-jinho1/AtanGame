using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _ri2;
    private Vector2 _moveDir;
    private float _speed = 5f;
     [SerializeField] private GameObject _player;
     [SerializeField] private GameObject _enemy;
     
     private void Awake()
     {
         _ri2 = GetComponent<Rigidbody2D>();
     }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = _player.transform.position;
        }
        
        
        _moveDir = _enemy.transform.position - transform.position;
        _ri2.velocity = _moveDir.normalized * _speed;
    }
}
