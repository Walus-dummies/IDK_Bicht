using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeviceState : PlayerBaseState
{
    public Transform playerPosition;
    public ThrottleComponent throttleComponent;

    public override void OnEnter(PlayerStateMachine _machine)
    {
        if(playerPosition != null)
        {
            _machine.gameObject.transform.parent = playerPosition;
            _machine.gameObject.transform.localPosition = Vector3.zero;
            _machine.gameObject.transform.localRotation = Quaternion.identity;
        }
    }

    public override void OnUpdate(PlayerStateMachine _machine)
    {
        if (Input.GetAxis("Vertical") > 0f && throttleComponent != null)
        {
            throttleComponent.Throttle();
        }
    }

    public override void OnExit(PlayerStateMachine _machine)
    {
        _machine.gameObject.transform.parent = null;
        playerPosition = null;
        throttleComponent = null;

    }
}
