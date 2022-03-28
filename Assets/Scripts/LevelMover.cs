using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMover : MonoBehaviour
{
   [SerializeField] private float _speed;

    void Update()
    {
        transform.position += Vector3.up * _speed * Time.deltaTime;
    }
    public void AddSpeed(float value)
    {
        _speed += value;

    }
}
