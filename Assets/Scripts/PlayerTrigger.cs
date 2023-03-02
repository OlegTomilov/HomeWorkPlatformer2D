using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnCollisionStay2D(Collision2D collision)
    {
        _player.IsGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _player.IsGround = false;
    }
}
