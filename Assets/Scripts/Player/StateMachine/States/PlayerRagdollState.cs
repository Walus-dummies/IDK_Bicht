using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRagdollState : PlayerBaseState
{
    // Variables privadas
    public float cooldown;

    // Variables privadas
    private float internalCooldown;
    public override void OnEnter(PlayerStateMachine _machine)
    {
        internalCooldown = cooldown;
        _machine.gameObject.GetComponent<PlayerMovement>().enabled = false;
        _machine.gameObject.GetComponent<CharacterController>().enabled = false;
        _machine.gameObject.AddComponent<Rigidbody>();
    }

    public override void OnUpdate(PlayerStateMachine _machine)
    {
        if (internalCooldown <= 0f)
        {
            if (_machine.gameObject.GetComponent<Rigidbody>().velocity.magnitude < 0.25f || Input.GetKeyDown(KeyCode.Space))
                _machine.SwitchState(_machine.moveState);
        }
        else
        {
            internalCooldown -= 1f * Time.deltaTime;
        }
    }

    public override void OnExit(PlayerStateMachine _machine)
    {
        Destroy(_machine.gameObject.GetComponent<Rigidbody>());
        _machine.gameObject.transform.rotation = Quaternion.identity;
        _machine.gameObject.GetComponent<CharacterController>().enabled = true;
        _machine.gameObject.GetComponent<PlayerMovement>().enabled = true;
    }
}
