using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    // Variables publicas
    public PlayerMovement playerMovement;
    public Climber climber;

    public override void OnEnter(PlayerStateMachine _machine)
    {
        
    }

    public override void OnUpdate(PlayerStateMachine _machine)
    {
        playerMovement.Movement();
        playerMovement.Gravity();

        if (climber.IsClimbing())
            _machine.SwitchState(_machine.climbState);
    }

    public override void OnExit(PlayerStateMachine _machine)
    {
        
    }
}
