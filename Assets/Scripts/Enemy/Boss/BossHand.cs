using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossHand : Enemy
{
    public UnityAction DisableHandEvent;
    public override void Death()
    {
        base.Death();
        DisableHandEvent?.Invoke();
    }
}
