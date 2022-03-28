using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToughnessController : MonoBehaviour
{
    [SerializeField] private EnemySpawner _sideEnemySpawner;
    [SerializeField] private EnemySpawner _flyEnemySpawner;
    [SerializeField] private EnemySpawner _secretEnemySpawner;
    [SerializeField] private LevelMover _levelMover;

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
            _sideEnemySpawner.SetSecondsBetweenSpawn(8);
            _flyEnemySpawner.SetSecondsBetweenSpawn(15);
        }
        else if(_time>=100 && !_secondLevel)
        {
            _secondLevel = true;
            _sideEnemySpawner.SetSecondsBetweenSpawn(6);
            _flyEnemySpawner.SetSecondsBetweenSpawn(12);
            _secretEnemySpawner.SetSecondsBetweenSpawn(40);
            _levelMover.AddSpeed(0.2f);
        }
        else if (_time >= 160 & !_thirdLevel)
        {
            _thirdLevel = true;
            _sideEnemySpawner.SetSecondsBetweenSpawn(3);
            _flyEnemySpawner.SetSecondsBetweenSpawn(8);
            _secretEnemySpawner.SetSecondsBetweenSpawn(25);
        }
        else if (_time >= 200 &_forthLevel)
        {
            _forthLevel = true;
            _sideEnemySpawner.SetSecondsBetweenSpawn(2);
            _flyEnemySpawner.SetSecondsBetweenSpawn(6);
            _secretEnemySpawner.SetSecondsBetweenSpawn(15);
            _levelMover.AddSpeed(0.2f);
        }
        else if (_time >= 300 &&!_fifthLevel)
        {
            _fifthLevel = true;
            _sideEnemySpawner.SetSecondsBetweenSpawn(1);
            _flyEnemySpawner.SetSecondsBetweenSpawn(3);
            _secretEnemySpawner.SetSecondsBetweenSpawn(10);
        }
    }
}
