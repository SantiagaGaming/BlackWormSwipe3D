using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    private void Update()
    {
        transform.Rotate(_rotateSpeed * Time.deltaTime, 0, 0);
    }
}
