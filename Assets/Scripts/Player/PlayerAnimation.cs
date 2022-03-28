using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        _playerMover.IdleEvent += OnSetIdleAnimation;
        _playerMover.UpMoveEvent += OnSetAttackAnimation;
        _playerMover.SideMoveEvent += OnSetMoveAnimation;
    }
    private void OnDisable()
    {
        _playerMover.IdleEvent -= OnSetIdleAnimation;
        _playerMover.UpMoveEvent -= OnSetAttackAnimation;
        _playerMover.SideMoveEvent -= OnSetMoveAnimation;
    }
    private void OnSetIdleAnimation()
    {
        _animator.SetTrigger("Idle");
    }
    private void OnSetMoveAnimation()
    {
        _animator.SetTrigger("Move");
    }
    private void OnSetAttackAnimation(bool value)
    {
        if (value)
            _animator.SetTrigger("Attack");
        else
        {
            OnSetIdleAnimation();
        }
    }    
}
