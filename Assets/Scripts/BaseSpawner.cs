using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawner : MonoBehaviour
{
    [SerializeField] private float _elapsedTime;
    [SerializeField] private GameObject _spawnObject;
    [SerializeField] private Transform[] _positions;
    protected void Start()
    {
        StartSpawn();
    }
    public virtual void StartSpawn()
    {
        StartCoroutine(BaseSpawn());
    }

    private IEnumerator BaseSpawn()
    {
        Instantiate(_spawnObject, _positions[Random.Range(0, _positions.Length)]);
        yield return new WaitForSeconds(Random.Range(_elapsedTime,_elapsedTime+10));
        StartCoroutine(BaseSpawn());
    }

}
