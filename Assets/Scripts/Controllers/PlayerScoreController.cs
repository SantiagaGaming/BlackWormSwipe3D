using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScoreController : MonoBehaviour
{
    public UnityAction <float> ScoreChangedEvent;

    [SerializeField] private PlayerMover _playerMover;
    private float _score;
    private void OnEnable()
    {
        _playerMover.PlayerYpozEvent += OnScoreChanged;
    }
    private void OnDisable()
    {
        _playerMover.PlayerYpozEvent -= OnScoreChanged;
    }
    private void OnScoreChanged(float value)
    {
        _score += value;
        ScoreChangedEvent?.Invoke(_score);
    }
    public void ReachedScoreObject(IScoreObject scoreobject)
    {
        OnScoreChanged(scoreobject.GetObjectScore());
    }
    public float GetPlayerScore()
    {
        return _score;
    }

}
