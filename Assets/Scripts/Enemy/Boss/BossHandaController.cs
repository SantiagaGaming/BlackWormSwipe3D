using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHandaController : MonoBehaviour
{
    [SerializeField] private BossHand _leftHand;
    [SerializeField] private BossHand _rightHand;
    private void Start()
    {
        ResetHandsPosition();
    }

    public void ResetHandsPosition()
    {
        int rnd = Random.Range(0, 2);
        if(rnd ==0)
        {
            _leftHand.transform.localPosition = new Vector3(0, 6.7f, 0);
            _rightHand.transform.localPosition = new Vector3(0, -6.6f, 0);
        }
        else
        {
            _leftHand.transform.localPosition = new Vector3(0, 0, 0);
            _rightHand.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
