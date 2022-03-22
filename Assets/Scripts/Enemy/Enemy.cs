using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _death;

    public void Death()
    {
        GetComponent<Collider>().enabled = false;
        _enemy.SetActive(false);
        _death.SetActive(true);
        StartCoroutine(DisableEnemy());
    }
    private IEnumerator DisableEnemy()
    {
        yield return new WaitForSeconds(0.7f);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Weapon weapon))
        {
            Death();
        }
    }
}
