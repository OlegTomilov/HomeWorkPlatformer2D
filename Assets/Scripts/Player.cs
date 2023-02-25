using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))] 
[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Animator _animator;
    private Rigidbody2D _rigidBody2D;
    private bool isGround;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
    }

    private void Move()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _animator.SetInteger(States.State, 2);
            ChangeToward(0);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _animator.SetInteger(States.State, 2);
            ChangeToward(180);
        }
        else if(Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
        else
        {
            _animator.SetInteger(States.State, 1);
        }
        
    }

    private void Jump()
    {
        if (isGround)
        {
            _rigidBody2D.AddForce(Vector2.up * _jumpForce);
        }
        else
        {
            _animator.SetInteger(States.State, 3);
        }
    }

    private void ChangeToward(int yAxis)
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.y = yAxis;
        transform.rotation = Quaternion.Euler(rotation);
    }
}

static class States
{
    public const string State = nameof(State);
}
