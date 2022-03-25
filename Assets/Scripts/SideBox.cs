using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBox : MonoBehaviour
{
    public void ResetBoxPosition()
    {
        float rnd = Random.Range(25, 60);
        transform.position += new Vector3(0, rnd, 0);
    }
}
