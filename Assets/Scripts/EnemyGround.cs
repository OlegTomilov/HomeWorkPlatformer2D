using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGround : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private Transform _goundDetect;

    private bool isMoveLeft = true;
   
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(_goundDetect.position, Vector2.down, 1f);

        if (groundInfo.collider == false)
        {
            if (isMoveLeft)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                isMoveLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isMoveLeft = true;
            }
        }
    }
}
