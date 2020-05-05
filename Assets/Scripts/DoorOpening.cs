using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : Trigger
{
    public override void Activate()
    {
        base.Activate();

        if (!IsTriggered)
        {
            gameObject.SetActive(false);
        }
    }
}
