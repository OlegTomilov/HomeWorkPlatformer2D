using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;

    private float _speed = 3f;
    private float _cameraZPosition = -10f;


    private void Start()
    {
        transform.position = new Vector3(_playerPosition.transform.position.x, _playerPosition.transform.position.y, _playerPosition.transform.position.z);
    }

    private void Update()
    {
        Vector3 position = _playerPosition.position;
        position.z = _cameraZPosition;
        transform.position = Vector3.Lerp(transform.position, position, _speed * Time.deltaTime);
    }
}
