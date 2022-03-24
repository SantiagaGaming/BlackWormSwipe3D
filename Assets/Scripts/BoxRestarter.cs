using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRestarter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out SideBox box))
        {
            box.ResetBoxPosition();
        }
    }
}
