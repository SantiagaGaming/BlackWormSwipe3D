using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _death;

    public virtual void Death()
    {
        GetComponent<Collider>().enabled = false;
        _enemy.SetActive(false);
        _death.SetActive(true);
        StartCoroutine(DisableEnemy());
    }
    private IEnumerator DisableEnemy()
    {
        yield return new WaitForSeconds(0.4f);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Weapon weapon))
        {
            Death();
        }
    }
    public void Revive()
    {
        _death.SetActive(false);
        _enemy.SetActive(true);
        GetComponent<Collider>().enabled = true;
    }
}
