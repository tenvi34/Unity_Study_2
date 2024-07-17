using UnityEngine;

public class MoveMyState : VMyState
{
    public float speed = 10.0f;
    
    public override void EnterState()
    {
        
    }

    public override void ExcuteState()
    {
        if (Input.GetKey(KeyCode.W))
        {
            stateMachine.transform.position += stateMachine.transform.forward * (Time.deltaTime * 10);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            stateMachine.transform.position -= stateMachine.transform.forward * (Time.deltaTime * 10);
        }
        else if (Input.GetKey(KeyCode.F))
        {
            stateMachine.ChangeState(EMyState.StunMyState);
        }
        else
        {
            stateMachine.ChangeState(EMyState.IdleMyState);
        }
    }

    public override void ExitState()
    {
        
    }
}