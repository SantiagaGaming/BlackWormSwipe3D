using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private MainMenuUi _viev;
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private CameraMover _cameraMover;

    private void Start()
    {
        _viev.ShowHighScore(Mathf.Round(LoadHighScore()).ToString());
    }

    private void OnEnable()
    {
        _viev.StartGameButtonTapEvent += OnLoadGameScene;
        _viev.HowToButonTapEvent += OnShowHowToPanel;
        _viev.BackButonTapEvent += OnBackToMainPanel;
    }
    private void OnDisable()
    {
        _viev.StartGameButtonTapEvent -= OnLoadGameScene;
        _viev.HowToButonTapEvent -= OnShowHowToPanel;
        _viev.BackButonTapEvent -= OnBackToMainPanel;
    }
    private void OnLoadGameScene()
    {
        _sceneLoader.LoadGameScene();
    }
    private float LoadHighScore()
    {
        if (PlayerPrefs.GetFloat("Score") != 0)
        {
            return PlayerPrefs.GetFloat("Score");
        }
        else return 0;
    }
    private void OnShowHowToPanel()
    {
        _viev.ShowHideHowToPanel(true);
        _cameraMover.ChangeCameraPosition();
    }
    private void OnBackToMainPanel()
    {
        _viev.ShowHideHowToPanel(false);
        _cameraMover.ChangeCameraPosition();
    }
}
