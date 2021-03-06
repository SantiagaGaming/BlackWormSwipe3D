using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner :Pool
{
    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondeBetweenSpawn;

    private float elapsed_Time = 0;
    [SerializeField] private bool _rotate;
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
        enemy.GetComponent<Enemy>().Revive();
        enemy.transform.position = spawnPoint;
        if(_rotate)
        CheckPosition(value, enemy);
        enemy.transform.parent = null;
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
    public void SetSecondsBetweenSpawn(float newSeconds)
    {
        _secondeBetweenSpawn = newSeconds;
    }
}
