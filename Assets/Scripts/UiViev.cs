using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UiViev : MonoBehaviour
{
    public UnityAction PauseButtonTapEvent;
    public UnityAction RestartButtonTapEvent;
    public UnityAction ExitButtonTapEvent;

    [SerializeField] private GameObject _endPauseScreen;
    [SerializeField] private GameObject _attackIcon;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private GameObject _exitButton;

    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _pauseText;
    [SerializeField] private Text _endPausePaneltext;

    [SerializeField] private Button _pauseButton;

    private void Start()
    {
        _pauseButton.onClick.AddListener(() => { PauseButtonTapEvent?.Invoke(); });
        _restartButton.GetComponent<Button>().onClick.AddListener(() => { RestartButtonTapEvent?.Invoke(); });
        _exitButton.GetComponent<Button>().onClick.AddListener(() => { ExitButtonTapEvent?.Invoke(); });
    }

    public void ShowAttackIcon(bool value)
    {
        _attackIcon.SetActive(value);
    }
    public void ShowScoreText(string score)
    {
        _scoreText.text = " Score: " + score;
    }
    public void ShowPauseScreen(bool value)
    {
        _endPauseScreen.SetActive(value);
        _endPausePaneltext.text = "Game Paused";
        if (value)
            _pauseText.text = "Resume";
        else
            _pauseText.text = "Pause";
    }
    public void ShowEndGameScreen()
    {
        _endPausePaneltext.text = "Game Over";
        _endPauseScreen.SetActive(true);
        _pauseButton.enabled = false;
    }
}
