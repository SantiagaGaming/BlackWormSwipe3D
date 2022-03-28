using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private MainMenuUi _viev;
    [SerializeField] private SceneLoader _sceneLoader;

    private void Start()
    {
        _viev.ShowHighScore(Mathf.Round(LoadHighScore()).ToString());
    }

    private void OnEnable()
    {
        _viev.StartGameButtonTapEvent += OnLoadGameScene;
    }
    private void OnDisable()
    {
        _viev.StartGameButtonTapEvent -= OnLoadGameScene;
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
}
