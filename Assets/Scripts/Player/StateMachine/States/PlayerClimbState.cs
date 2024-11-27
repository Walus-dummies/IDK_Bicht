using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbState : PlayerBaseState
{
    // Variables publicas
    public PlayerMovement playerMovement;
    public Climber climbComponent;

    public override void OnEnter(PlayerStateMachine _machine)
    {
        
    }

    public override void OnUpdate(PlayerStateMachine _machine)
    {
        playerMovement.Climb();

        if (!climbComponent.IsClimbing())
            _machine.SwitchState(_machine.moveState);
    }

    public override void OnExit(PlayerStateMachine _machine)
    {
        
    }
}
