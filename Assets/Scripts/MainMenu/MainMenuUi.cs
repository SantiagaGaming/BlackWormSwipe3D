using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuUi : MonoBehaviour
{
    public UnityAction StartGameButtonTapEvent;
    public UnityAction HowToButonTapEvent;
    public UnityAction BackButonTapEvent;
    public UnityAction SoundButtonTap;

    [SerializeField] private GameObject _howToPanel;
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _howToButon;
    [SerializeField] private Text _highScoreText;
    [SerializeField] private Text _soundText; 
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _soundButton;
    private void Start()
    {
        _startGameButton.onClick.AddListener(() => { StartGameButtonTapEvent?.Invoke(); });
        _howToButon.onClick.AddListener(() => { HowToButonTapEvent?.Invoke(); });
        _backButton.onClick.AddListener(() => { BackButonTapEvent?.Invoke(); });
        _soundButton.onClick.AddListener(() => { SoundButtonTap?.Invoke(); });
    }
    public void ShowHideHowToPanel(bool value)
    {
            _howToPanel.SetActive(value);
            _mainPanel.SetActive(!value);
     }
    public void ShowHighScore(string score)
    {
        _highScoreText.text = "High score: "+ score;
    }
    public void SetSoundText(bool value)
    {
        if(value)
            _soundText.text = "Sound ON";
        else
            _soundText.text = "Sound OFF";
    }
}
