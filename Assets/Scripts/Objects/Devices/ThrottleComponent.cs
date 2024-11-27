using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ThrottleComponent : MonoBehaviour
{
    // Variables publicas
    public UnityEvent onThrottle;

    public void Throttle()
    {
        onThrottle.Invoke();
    }
}
