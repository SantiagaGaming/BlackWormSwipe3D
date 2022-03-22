using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPositionChanger : MonoBehaviour
{
    [SerializeField] private Box[] _boxes;
    [SerializeField] private Transform[] _positions;
    private void Start()
    {
        foreach (var box in _boxes)
        {
            box.ResetBoxPositionEvent += OnSetNewBoxPosition;
        }
    }
    private void OnSetNewBoxPosition(Box box)
    {
        box.SetBoxPosition(_positions[Random.Range(0, _positions.Length)]);
    }
}
