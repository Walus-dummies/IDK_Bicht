using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class ExerciseWheel : MonoBehaviour
{
    // Variables publicas
    public Transform wheel, playerPosition;
    public float acceleration, maxSpeed;
    public PlayerStateMachine playerStateMachine;

    // Variables privadas
    private float speed = 0f;
    private bool inUse = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();

        if(!inUse)
            Decelerate();
    }

    public void Rotate()
    {
        wheel.Rotate(Vector3.up * speed * Time.deltaTime);
    }

    public void Interaction()
    {
        if (inUse)
        {
            inUse = false;
            playerStateMachine.SwitchState(playerStateMachine.moveState);
        }
        else
        {
            playerStateMachine.deviceState.playerPosition = playerPosition;
            playerStateMachine.deviceState.throttleComponent = gameObject.GetComponent<ThrottleComponent>();
            playerStateMachine.SwitchState(playerStateMachine.deviceState);
            inUse = true;
        }
    }

    public void Throttle()
    {
        if (speed < maxSpeed)
        {
            speed += acceleration * Time.deltaTime;
        }
        else
        {
            playerStateMachine.Death();
        }
    }

    public void Decelerate()
    {
        if (speed > 0f)
        {
            speed -= acceleration * Time.deltaTime;
        }
    }
    public void SetInUse(bool _state)
    {
        inUse = _state;
    }
}
