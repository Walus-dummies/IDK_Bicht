using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    // variables publicas
    public UnityEvent onInteract;

    // Funcion de interaccion
    public void Interaction()
    {
        onInteract.Invoke();
    }
}
