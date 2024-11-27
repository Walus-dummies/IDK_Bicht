using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    // Variables publicas
    public bool startCursorState;

    // Start is called before the first frame update
    void Start()
    {
        SetCursorState(startCursorState);
    }

    // Funcion para cambiar el estado del cursor
    public void SetCursorState(bool _state)
    {
        if (_state)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
