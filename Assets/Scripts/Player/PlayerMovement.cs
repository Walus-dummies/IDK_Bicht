using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class PlayerMovement : MonoBehaviour
{
    // Variables publicas
    public Transform cameraAim;
    public float walkSpeed, runSpeed, jumpForce, rotationSpeed;
    public GroundDetector groundDetector;

    // Variables privadas;
    private Vector3 vectorMovement, verticalForce;
    private float targetSpeed, currentSpeed;
    private bool isGrounded, canMove;
    private CharacterController characterController;

    // Start function
    private void Start()
    {
        // Inicializacion de variables
        characterController = GetComponent<CharacterController>();
        canMove = true;
        currentSpeed = 0f;
        verticalForce = Vector3.zero;
        vectorMovement = Vector3.zero;
    }

    private void Update()
    {
        CheckGround();
    }

    // Funcion de movimiento
    public void Movement()
    {
        // Si nos podemos mover
        if (canMove)
        {
            Walk();
            Run();
            AlignPlayer();
            Jump();
        }
    }

    // Funcion para caminar
    public void Walk()
    {
        // Conseguimos los inputs
        vectorMovement.x = Input.GetAxis("Horizontal");
        vectorMovement.z = Input.GetAxis("Vertical");

        // Normalizamos el vector de movimiento
        vectorMovement = vectorMovement.normalized;

        // Nos movemos en direccion a la camara
        vectorMovement = cameraAim.TransformDirection(vectorMovement);

        // Guardamos la velocidad actual con suavizado
        currentSpeed = Mathf.Lerp(currentSpeed, vectorMovement.magnitude * targetSpeed, 10f * Time.deltaTime);

        // Nos movemos
        characterController.Move(vectorMovement * currentSpeed * Time.deltaTime);
    }

    // Funcion para correr
    public void Run()
    {
        // Si presionamos el boton para correr modificamos la velocidad
        if (Input.GetAxis("Run") > 0f)
        {
            targetSpeed = runSpeed;
        }
        else
        {
            targetSpeed = walkSpeed;
        }
    }

    // Funcion para saltar
    void Jump()
    {
        // Si estamos tocando el suelo
        if (isGrounded && Input.GetAxis("Jump") > 0f)
        {
            verticalForce = new Vector3(0f, jumpForce, 0f);
            isGrounded = false;
        }
    }

    public void Climb()
    {
        // Conseguimos el input vertical
        vectorMovement.y = Input.GetAxis("Vertical");

        // Guardamos la velocidad actual con suavizado
        currentSpeed = Mathf.Lerp(currentSpeed, vectorMovement.magnitude * targetSpeed, 10f * Time.deltaTime);

        // Nos movemos
        characterController.Move(new Vector3(0f, vectorMovement.y, 0f) * currentSpeed * Time.deltaTime);
        vectorMovement = Vector3.zero;
    }

    // Funcion de gravedad
    public void Gravity()
    {
        if (!isGrounded)
        {
            // Aumentamos la aceleracion de la gravedad
            verticalForce += Physics.gravity * Time.deltaTime;
        }
        else
        {
            verticalForce = new Vector3(0f, -2f, 0f);
        }

        // Aplicamos la fuerza vertical
        characterController.Move(verticalForce * Time.deltaTime);
    }

    // Alineacion del player al moverse
    void AlignPlayer()
    {
        // Si nos estamos moviendo alineamos la rotacion
        if (characterController.velocity.magnitude > 0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(vectorMovement), rotationSpeed * Time.deltaTime);
        }
    }

    // Funcion para ver si estamos tocando el suelo
    void CheckGround()
    {
        isGrounded = groundDetector.GetIsGrounded();
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    public void CanMove(bool _state)
    {
        canMove = _state;
    }
}
