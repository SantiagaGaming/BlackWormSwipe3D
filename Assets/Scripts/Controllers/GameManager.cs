using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UiViev _viev;
    [SerializeField] private PauseController _pauseController;
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerScoreController _playerScore;

    private bool _paused = false;

    private void OnEnable()
    {
        _viev.PauseButtonTapEvent += OnShowPauseScreen;
        _viev.ExitButtonTapEvent += OnExitToMenu;
        _viev.RestartButtonTapEvent += OnRestartGame;
        _player.PlayerDiedEvent += OnGameOver;
        _playerMover.UpMoveEvent += OnShowWeaponIcon;
        _playerScore.ScoreChangedEvent += OnSetNewScore;
    }
    private void OnDisable()
    {
        _viev.PauseButtonTapEvent -= OnShowPauseScreen;
        _viev.ExitButtonTapEvent -= OnExitToMenu;
        _viev.RestartButtonTapEvent -= OnRestartGame;
        _player.PlayerDiedEvent -= OnGameOver;
        _playerMover.UpMoveEvent -= OnShowWeaponIcon;
        _playerScore.ScoreChangedEvent -= OnSetNewScore;
    }
    private void OnShowPauseScreen()
    {
        if (!_paused)
        {
            _viev.ShowPauseScreen(true);
            _paused = true;
            _pauseController.EnablePause(_paused);
        }
        else
        {
            _viev.ShowPauseScreen(false);
            _paused = false;
            _pauseController.EnablePause(_paused);
        }
    }
    private void OnExitToMenu()
    {
        _pauseController.EnablePause(false);
        _sceneLoader.LoadMenuScene();
    }
    private void OnRestartGame()
    {
        _pauseController.EnablePause(false);
        _sceneLoader.LoadGameScene();
    }
    private void OnGameOver()
    {
        _viev.ShowEndGameScreen();
        _pauseController.EnablePause(true);
    }
    private void OnShowWeaponIcon(bool value)
    {
        _viev.ShowAttackIcon(!value);
    }
    private void OnSetNewScore(float value)
    {
        _viev.ShowScoreText(Mathf.Round(value).ToString());
    }
}
