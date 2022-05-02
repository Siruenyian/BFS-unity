using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;

    void Start()
    {
        //InvokeRepeating("LaunchEnemy", 2.0f, 3.0f);
        LaunchEnemy();
    }
    void LaunchEnemy()
    {
        Instantiate(_playerPrefab, transform.position, Quaternion.identity);

    }
}
