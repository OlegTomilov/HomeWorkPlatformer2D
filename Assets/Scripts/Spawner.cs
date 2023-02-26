using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Transform _spawn;
    [SerializeField] private float _timeSpawn;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var timeSpawn = new WaitForSeconds(_timeSpawn);

        while (true)
        {
            Instantiate(_coin, _spawn.transform.position, transform.rotation);
            yield return timeSpawn;
        }
    }
}
