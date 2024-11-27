using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    // Variables publicas
    public float newCameraDistance, speed, rotationSpeed;
    public CameraController cameraController;
    public CinemachineVirtualCamera virtualCamera;

    // Variables privadas
    private Cinemachine3rdPersonFollow thirdPersonComponent;

    public override void OnEnter(PlayerStateMachine _machine)
    {
        cameraController.CanRotate(false);
        thirdPersonComponent = virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
        _machine.gameObject.GetComponent<PlayerMovement>().enabled = false;
        _machine.gameObject.GetComponent<CharacterController>().enabled = false;
        _machine.gameObject.AddComponent<Rigidbody>();
        _machine.gameObject.GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(50f, 0f, 0f));
    }

    public override void OnUpdate(PlayerStateMachine _machine)
    {
        thirdPersonComponent.CameraDistance = Mathf.Lerp(thirdPersonComponent.CameraDistance, newCameraDistance, speed * Time.deltaTime);
        cameraController.gameObject.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

    }

    public override void OnExit(PlayerStateMachine _machine)
    {
        
    }
}
