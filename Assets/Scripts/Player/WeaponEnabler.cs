using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMover))]
public class WeaponEnabler : MonoBehaviour
{
    [SerializeField] private GameObject _weapon;
    private PlayerMover _playerMover;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
    }
    private void OnEnable()
    {
        _playerMover.UpMoveEvent += OnEnableWeapon;
    }
    private void OnDisable()
    {
        _playerMover.UpMoveEvent -= OnEnableWeapon;
    }

    private void OnEnableWeapon(bool value)
    {
        _weapon.SetActive(value);
    }
}
