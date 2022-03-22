using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Box : MonoBehaviour
{
    public UnityAction <Box> ResetBoxPositionEvent;
    [SerializeField] private GameObject _enemyLeft;
    [SerializeField] private GameObject _enemyRight;
    private void Start()
    {
        transform.position = new Vector3(Random.Range(-0.7f, 0.7f), transform.position.y, transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Restarter restarter))
        {
            ResetBoxPositionEvent?.Invoke(this);
        }
    }
    public void SetBoxPosition(Transform newpos)
    {
        transform.position = newpos.position;
        transform.parent = null;
        EnableEnemyOnBox();
    }
    private void EnableEnemyOnBox()
    {
        int rnd = Random.Range(0, 3);
        switch(rnd)
        {
            case 0:
                _enemyLeft.SetActive(false);
                _enemyRight.SetActive(false);
                break;
            case 1:
                _enemyLeft.SetActive(true);
                _enemyRight.SetActive(false);
                break;
            case 2:
                _enemyLeft.SetActive(false);
                _enemyRight.SetActive(true);
                break;
        }
    }
}
