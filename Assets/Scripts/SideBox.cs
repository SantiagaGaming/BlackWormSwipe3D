using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBox : MonoBehaviour
{
    [SerializeField] SideBox _otherSideBox;
    public void ResetBoxPosition()
    {
        float rnd = Random.Range(10, 25);
        transform.position = new Vector3(transform.position.x, _otherSideBox.transform.position.y, transform.position.z);
        transform.position += new Vector3(0, rnd, 0);
    }
}
