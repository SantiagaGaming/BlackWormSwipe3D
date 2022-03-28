using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuUi : MonoBehaviour
{
    public UnityAction StartGameButtonTapEvent;
    public UnityAction HowToButonTapEvent;

    [SerializeField] private GameObject _howToPanel;
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _howToButon;
    [SerializeField] private Text _highScoreText;
    private void Start()
    {
        _startGameButton.onClick.AddListener(() => { StartGameButtonTapEvent?.Invoke(); });
        _howToButon.onClick.AddListener(() => { HowToButonTapEvent?.Invoke(); });
    }
    public void ShowHideHowToPanel(bool value)
    {
        if (value)
        {
            _howToPanel.SetActive(value);
            _mainPanel.SetActive(!value);
        }
        else
        {
            _howToPanel.SetActive(!value);
            _mainPanel.SetActive(value);
        }
     }
    public void ShowHighScore(string score)
    {
        _highScoreText.text = "High score: "+ score;
    }
}
