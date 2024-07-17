using UnityEngine;

public class IdleMyState : VMyState
{
    public override void EnterState()
    {
        
    }

    public override void ExcuteState()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            stateMachine.ChangeState(EMyState.MoveMyState);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            stateMachine.ChangeState(EMyState.StunMyState);
        }
    }

    public override void ExitState()
    {
        
    }
}