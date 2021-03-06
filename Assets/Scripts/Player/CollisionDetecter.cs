using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
public class CollisionDetecter : MonoBehaviour
{
    public UnityAction LeftWallTouchedEvent;
    public UnityAction RightWallTouchedEvent;
    public UnityAction EnemyCollideEvent;

    private PlayerMover _playerMover;
    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out LeftWall leftWall))
        {
            _playerMover.SideMoveAllower(true, false);
            _playerMover.SetGround(true);
            LeftWallTouchedEvent?.Invoke();
        }
        if (collision.gameObject.TryGetComponent(out RightWall rightWall))
        {
            _playerMover.SideMoveAllower(false, true);
            _playerMover.SetGround(true);
            RightWallTouchedEvent?.Invoke();
        }
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            EnemyCollideEvent?.Invoke();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out LeftWall leftWall))
        {
            _playerMover.SideMoveAllower(false, false);
            _playerMover.SetGround(false);
        }
        if (collision.gameObject.TryGetComponent(out RightWall rightWall))
        {
            _playerMover.SideMoveAllower(false,false);
            _playerMover.SetGround(false);
        }

  

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Lava lava))
        {
            EnemyCollideEvent?.Invoke();
        }
    }
}
