using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _attackSound, _loseSound, _enemyDieSound, _flySound;

    public static SoundPlayer Instance;
    private SoundPlayer() { }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void PlayAttackSound()
    {
        _audioSource.PlayOneShot(_attackSound);
    }

    public void PlayLoseSound()
    {
        _audioSource.PlayOneShot(_loseSound);
    }
    public void PlayEnemyDieSound()
    {
        _audioSource.PlayOneShot(_enemyDieSound);
    }

    public void PlayFlySound()
    {
        _audioSource.PlayOneShot(_flySound);
    }
}

