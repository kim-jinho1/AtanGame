using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Atan : MonoBehaviour
{
    private Rigidbody2D _ri2;
    private Vector2 _moveDir;
    private float _speed = 5f;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private TextMeshProUGUI _ming;
    [SerializeField] private GameObject _laser;

    [SerializeField] private float _attackRange = 3.0f;
    private bool _gameStarted;

    private List<Enemy> enemy;

    
    public Enemy Target { get; set; }
    
    
    public float AttackRange => _attackRange;
    

    private void Awake()
    {
        _laser.transform.position = transform.position;
        _gameStarted = true;
        enemy = new List<Enemy>();
        _ri2 = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetCurrentEnemytTarget();
        PlayerRotation();
    }

    private void PlayerRotation()
    {
        if (Target == null)
        {
            return;
        }
       
        Vector3 direction = Target.transform.position - transform.position;
        float angle = Mathf.Atan(direction.y/direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        
        
        _laser.transform.rotation = Quaternion.Euler(0, 0, angle);
        _ming.text = angle.ToString();
    }
   

    private void OnDrawGizmos()
    {
        if(!_gameStarted)
        {
            GetComponent<CircleCollider2D>().radius = _attackRange;
        }    
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }

    private void GetCurrentEnemytTarget()
    {
        if(enemy.Count <= 0)
        {
            Target = null;
            return;
        }
        Target = enemy[0];
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Enemy newEnemy = collision.GetComponent<Enemy>();
            enemy.Add(newEnemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy newEnemy = collision.GetComponent<Enemy>();
            if(enemy.Contains(newEnemy))
                enemy.Remove(newEnemy);
        }
    }
    
}
