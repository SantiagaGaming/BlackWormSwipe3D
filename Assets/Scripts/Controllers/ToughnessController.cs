using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToughnessController : MonoBehaviour
{
    [SerializeField] private EnemySpawner _sideEnemySpawner;
    [SerializeField] private EnemySpawner _flyEnemySpawner;
    [SerializeField] private EnemySpawner _secretEnemySpawner;

    private bool _firstLevel = false;
    private bool _secondLevel = false;
    private bool _thirdLevel = false;
    private bool _forthLevel = false;
    private bool _fifthLevel = false;

    private float _time;

    private void Update()
    {
        _time += Time.deltaTime;
        CheckGameTime();
    }

    private void CheckGameTime()
    {
        if(_time>=40 && !_firstLevel)
        {
            _firstLevel = true;
            _sideEnemySpawner.SetSecondsBetweenSpawn(12);
            _flyEnemySpawner.SetSecondsBetweenSpawn(16);
        }
        else if(_time>=100 && !_secondLevel)
        {
            _secondLevel = true;
            _sideEnemySpawner.SetSecondsBetweenSpawn(10);
            _flyEnemySpawner.SetSecondsBetweenSpawn(14);
            _secretEnemySpawner.SetSecondsBetweenSpawn(30);
        }
        else if (_time >= 160 & !_thirdLevel)
        {
            _thirdLevel = true;
            _sideEnemySpawner.SetSecondsBetweenSpawn(8);
            _flyEnemySpawner.SetSecondsBetweenSpawn(12);
            _secretEnemySpawner.SetSecondsBetweenSpawn(25);
        }
        else if (_time >= 200 &_forthLevel)
        {
            _forthLevel = true;
            _sideEnemySpawner.SetSecondsBetweenSpawn(7);
            _flyEnemySpawner.SetSecondsBetweenSpawn(10);
            _secretEnemySpawner.SetSecondsBetweenSpawn(20);
        }
        else if (_time >= 300 &&!_fifthLevel)
        {
            _fifthLevel = true;
            _sideEnemySpawner.SetSecondsBetweenSpawn(5);
            _flyEnemySpawner.SetSecondsBetweenSpawn(8);
            _secretEnemySpawner.SetSecondsBetweenSpawn(16);
        }
    }
}
