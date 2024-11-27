

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // variables publicas
    public float sensibility;
    public Transform cameraJointY;

    public Transform targetObject;

    // Variables privadas
    private float xRotation, yRotation;
    private bool canRotate = true;

    // Singleton
    public CameraController Instance { get; private set; }

    // Comprobacion del singleton
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Inicializacion de variables
        canRotate = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Si podemos rotar rotamos
        if (canRotate)
        {
            Rotate();
        }
        
        // Seguimos al objetivo
        FollowTarget();
    }

    // Funcion de rotacion
    public void Rotate()
    {
        // Conseguimos los inputs del mouse
        xRotation += Input.GetAxis("Mouse X") * sensibility;
        yRotation += Input.GetAxis("Mouse Y") * sensibility;

        // Ponemos limitacion en el eje Y
        yRotation = Mathf.Clamp(yRotation, -65, 65);

        // Rotamos los componentes X y Y de la camara
        transform.rotation = Quaternion.Euler(0f, xRotation, 0f);
        cameraJointY.localRotation = Quaternion.Euler(-yRotation, 0f, 0f);
    }

    // Funcion para seguir al objetivo
    void FollowTarget()
    {
        transform.position = targetObject.position;
    }

    // Funcion para cambiar el estado de la rotacion
    public void CanRotate(bool _state)
    {
        canRotate = _state;
    }

    // Funcion para cambiar el objetivo de la camara
    public void SetTarget(Transform _target)
    {
        targetObject = _target;
    }
}
