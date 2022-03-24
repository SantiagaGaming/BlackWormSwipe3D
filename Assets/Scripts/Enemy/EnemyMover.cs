using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
   [SerializeField] private float _moveSpeed;
   [SerializeField] private bool _side;
   private Vector3 _moveDirection;
    private void Start()
    {
        if (_side)
            _moveDirection = Vector3.right;
        else
            _moveDirection = Vector3.down;

    }
    private void Update()
    {
        transform.Translate(_moveDirection* _moveSpeed * Time.deltaTime);
    }
    public void SetEnemyWalkSpeed(float speed)
    {
        _moveSpeed = speed;
    }
}
