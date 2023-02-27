using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    private int _idleState = 1;
    private int _moveState = 2;
    private int _jumpState = 3;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayAnimation();
    }

    public void PlayAnimation()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            _animator.SetInteger(States.State, _moveState);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            _animator.SetInteger(States.State, _jumpState);
        }
        else
        {
            _animator.SetInteger(States.State, _idleState);
        }
    }
}

static class States
{
    public const string State = nameof(State);
}
