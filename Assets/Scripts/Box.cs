using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Box : MonoBehaviour
{
    public UnityAction <Box> ResetBoxPositionEvent;
    [SerializeField] private GameObject _enemy;
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
        if(_enemy!= null)
        {
            _enemy.SetActive(true);
        }
        transform.position = newpos.position;
        transform.parent = null;
    }
}
