using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    // Variables publicas
    public PlayerMoveState moveState;
    public PlayerDeadState deadState;
    public PlayerClimbState climbState;
    public PlayerRagdollState ragdollState;
    public PlayerDeviceState deviceState;

    // Variables privadas
    private PlayerBaseState currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = moveState;
        currentState.OnEnter(this);
    }

    private void Update()
    {
        if(currentState != null)
        {
            currentState.OnUpdate(this);
        }
    }

    // Funcion para cambiar de estado
    public void SwitchState(PlayerBaseState _state)
    {
        currentState.OnExit(this);
        currentState = _state;
        currentState.OnEnter(this);
    }

    public void Death()
    {
        SwitchState(deadState);
    }

    public void ActivateRagdoll()
    {
        if (currentState == moveState)
        {
            SwitchState(ragdollState);
        }
    }
}
