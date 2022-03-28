using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _menuPos;
    [SerializeField] private Transform _howToPos;

    public void ChangeCameraPosition()
    {
        if (transform.position != _menuPos.position)
        {
            transform.position = _menuPos.position;
            transform.rotation = _menuPos.rotation;
        }
        else
        {
            transform.position = _howToPos.position;
            transform.rotation = _howToPos.rotation;
        }
    }
}
