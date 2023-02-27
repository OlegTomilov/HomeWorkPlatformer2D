using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidBody2D;

    private bool _isGround;

    private void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        _isGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGround = false;
    }

    private void Move()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            ChangeToward(0);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            ChangeToward(180);
        }
        else if(Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (_isGround)
        {
            _rigidBody2D.AddForce(Vector2.up * _jumpForce);
        }
    }

    private void ChangeToward(int yAxis)
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.y = yAxis;
        transform.rotation = Quaternion.Euler(rotation);
    }
}