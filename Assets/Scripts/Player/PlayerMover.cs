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

    [HideInInspector]public bool CanMove = true;

    private CollisionDetecter _collisionDetecter;
    private bool _isGrounded = true;
    private bool _right = false;
    private bool _left = false;
    private bool _up = true;

    private float _speed = 8f;
    private float _moveUpForce = 25f;
    private Vector3 _movingVector;
    private PlayerState _currentState;
    private Rigidbody _rb;
    private void Awake()
    {
        _collisionDetecter = GetComponent<CollisionDetecter>();
    }
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
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
            SoundPlayer.Instance.PlayFlySound();
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
            SoundPlayer.Instance.PlayFlySound();
        }
    }
    private void Move()
    {
        if(CanMove)
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
    }

   private IEnumerator StartMoveUp()
    {
        SoundPlayer.Instance.PlayAttackSound();
        UpMoveEvent?.Invoke(true);
        _up = false;
        _rb.AddForce(transform.up * -_moveUpForce, ForceMode.Impulse);
        yield return new WaitForSeconds(0.4f);
        _rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(0.4f);
        UpMoveEvent?.Invoke(false);
        _up = true;
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
        _moveUpForce = 55;
    }
    private void OnRightWallStand()
    {
        transform.localRotation = Quaternion.Euler(180, 0, 90);
        _moveUpForce = 20;
    }
}
