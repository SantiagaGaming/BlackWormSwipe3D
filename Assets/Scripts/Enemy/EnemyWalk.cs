using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
   [SerializeField] private float _moveSpeed;
 private void Update()
    {
        transform.Translate(Vector3.down * _moveSpeed * Time.deltaTime);
    }
    public void SetEnemyWalkSpeed(float speed)
    {
        _moveSpeed = speed;
    }
}
