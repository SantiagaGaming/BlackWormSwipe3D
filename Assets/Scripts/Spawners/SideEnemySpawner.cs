using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideEnemySpawner :Pool
{
    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondeBetweenSpawn;
    private float elapsed_Time = 0;
    private void Start()
    {
        Initialize(_enemies);
    }
    private void Update()
    {
        elapsed_Time += Time.deltaTime;
        if (elapsed_Time >= _secondeBetweenSpawn)
        {
            if (TryGetPrefub(out GameObject enemy))
            {
                elapsed_Time = 0;
                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
                SetEnemy(enemy, _spawnPoints[spawnPointNumber].position, spawnPointNumber);
            }
        }
    }
    private void SetEnemy(GameObject enemy, Vector3 spawnPoint, int value)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
        CheckPosition(value, enemy);
    }
    private void CheckPosition(int value, GameObject enemy)
    {
        if (value == 0)
        {
            enemy.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (value == 1)
        {
            enemy.transform.rotation = Quaternion.Euler(0, 0,0 );
        }

    }
}
