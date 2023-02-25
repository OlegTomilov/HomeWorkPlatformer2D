using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlight : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentPoint;

    private void Start()
    {
        AddPoints();
    }

    private void Update()
    {
        Move();
    }

    private void AddPoints()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Move()
    {
        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if(transform.position == target.position)
        {
            transform.eulerAngles = new Vector3(0, transform.rotation.y - 180, 0);
            _currentPoint++;

            if(_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
                transform.eulerAngles = new Vector3(0, transform.rotation.y, 0);

            }
        }
    }
}
