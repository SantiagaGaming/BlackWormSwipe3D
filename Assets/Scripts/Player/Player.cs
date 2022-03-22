using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(CollisionDetecter))]
public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _worm;
    [SerializeField] private GameObject _death;

    private CollisionDetecter _collisionDetecter;
    private PlayerMover _playerMover;
    private void Awake()
    {
        _collisionDetecter = GetComponent<CollisionDetecter>();
        _playerMover = GetComponent<PlayerMover>();
    }
    private void OnEnable()
    {
        _collisionDetecter.EnemyCollideEvent += OnDeath;
    }
    private void OnDisable()
    {
        _collisionDetecter.EnemyCollideEvent -= OnDeath;
    }
    private void OnDeath()
    {
        _worm.SetActive(false);
        _death.SetActive(true);
        _playerMover.CanMove = false;
        GetComponent<Collider>().enabled = false;
        StartCoroutine(DisableDeathObject());
    }
    private IEnumerator DisableDeathObject()
    {
        yield return new WaitForSeconds(0.5f);
            _death.SetActive(false);
    }
}

