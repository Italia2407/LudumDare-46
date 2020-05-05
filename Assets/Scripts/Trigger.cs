using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private bool isTriggered = false;

    public bool IsTriggered { get => isTriggered; }

    public virtual void Activate()
    {
        if (!isTriggered)
        {
            Debug.Log("Trigger has been activated!");
        }
    }
}
