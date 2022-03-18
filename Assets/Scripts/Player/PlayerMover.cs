using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
enum PlayerState
{
    leftMoving,
    rightMoving,
    leftStanding,
    rightStanding,
    attack,
    death,
    idle
}

public class PlayerMover : MonoBehaviour
{
    public UnityAction <bool> UpMoveEvent;
    public UnityAction SideMoveEvent;
    public UnityAction IldeEvent;

    private CollisionDetecter _collisionDetecter;
    private bool _isGrounded = true;
    private bool _right = false;
    private bool _left = false;
    private bool _up = true;

    private float _speed = 8f;
    private float _moveUpForce = 35f;
    private Vector3 _upVector;
    private Vector3 _movingVector;
     private PlayerState _currentState;
    private void Awake()
    {
        _collisionDetecter = GetComponent<CollisionDetecter>();
    }
    private void Start()
    {
        _currentState = PlayerState.idle;
      
    }
    private void Update()
    {
        Move();
    }
    private void OnEnable()
    {
        _collisionDetecter.RightWallTouchedEvent += OnRightWallStand;
        _collisionDetecter.LeftWallTouchedEvent += OnLeftWallStand;
    }
    private void OnDisable()
    {
        _collisionDetecter.RightWallTouchedEvent -= OnRightWallStand;
        _collisionDetecter.LeftWallTouchedEvent -= OnLeftWallStand;
    }

    public void MoveUp()
    {
        if (_up && _isGrounded)
        {
            if (_left || _right)
            {
                _upVector = Vector3.up;
                StartCoroutine(StartMoveUp());
            }
            else if (!_right)
            {
                _upVector = Vector3.right;
                StartCoroutine(StartMoveUp());
            }
            else if (!_left)
            {
                _upVector = Vector3.left;
                StartCoroutine(StartMoveUp());
            }

        }
    }

    public void MoveLeft()
    {
      
        _currentState = PlayerState.leftMoving;
        _movingVector = Vector3.left;
        _speed = 8;
        if(!_left)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            SideMoveEvent?.Invoke();
        }
  
    }
    public void MoveRight()
    {
        _currentState = PlayerState.rightMoving;
        _movingVector = Vector3.right;
        _speed = 8;
        if (!_right)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            SideMoveEvent?.Invoke();
        }
 

    }
    private void Move()
    {
        if (_currentState == PlayerState.rightMoving && !_right)
        {
            transform.position += _movingVector * _speed * Time.deltaTime;
        }
        if (_currentState == PlayerState.leftMoving && !_left)
        {
            transform.position += _movingVector * _speed * Time.deltaTime;
        }
        else transform.position = transform.position;
    }

   private IEnumerator StartMoveUp()
    {
        UpMoveEvent?.Invoke(true);
        _up = false;
        int counter = 0;
        while(counter<15)
        {
            yield return new WaitForSeconds(0.02f);
            transform.position += _upVector * _moveUpForce * Time.deltaTime;
            counter++;
        }

        _up = true;
        yield return new WaitForSeconds(0.5f);
        UpMoveEvent?.Invoke(false);
    }
    public void SideMoveAllower(bool left, bool right)
    {
        _left = left;
        _right = right;

    }
    public void SetGround(bool value)
    {
        _isGrounded = value;
        CheckGound();
    }
    private void CheckGound()
    {
        if(_isGrounded)
        {
            _speed = 0;
            IldeEvent?.Invoke();
        }
        else if(!_isGrounded)
        {
            _speed = 8;
        }
    }
    private void OnLeftWallStand()
    {
        transform.localRotation = Quaternion.Euler(180, 180, 90);
    }
    private void OnRightWallStand()
    {
        transform.localRotation = Quaternion.Euler(180, 0, 90);
    }
}
