using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private GameObject _boss;
    [SerializeField] private GameObject _death;
    [SerializeField] private GameObject _leftHand;
    [SerializeField] private GameObject _rightHand;

    private int _hp = 2;
    private void OnEnable()
    {
        _leftHand.GetComponent<BossHand>().DisableHandEvent += OnTakeDamage;
        _rightHand.GetComponent<BossHand>().DisableHandEvent += OnTakeDamage;
    }
    private void OnDisable()
    {
        _leftHand.GetComponent<BossHand>().DisableHandEvent -= OnTakeDamage;
        _rightHand.GetComponent<BossHand>().DisableHandEvent -= OnTakeDamage;
    }
    private void OnTakeDamage()
    {
        _hp --;
        CheckDeath();
    }
    private void CheckDeath()
    {
        if(_hp<1)
        {
            EnableBoss(false);
            StartCoroutine(MoveBossUp());
        }
    }
    private void EnableBoss(bool value)
    {
        GetComponent<Collider>().enabled = value;
        _boss.SetActive(value);
        _death.SetActive(!value);
    }
    private IEnumerator MoveBossUp()
    {
        yield return new WaitForSeconds(0.4f);
        transform.position += new Vector3(0, 200, 0);
        EnableBoss(true);
        _leftHand.SetActive(true);
        _rightHand.SetActive(true);
        _leftHand.GetComponent<BossHand>().Revive();
        _rightHand.GetComponent<BossHand>().Revive();
    }
}
