using System.Collections;
using UnityEngine;

public class StunMyState : VMyState
{
    IEnumerator Stun()
    {
        yield return new WaitForSeconds(3.0f);
        stateMachine.ChangeState(EMyState.IdleMyState);
    }
    
    public override void EnterState()
    {
        stateMachine.StartCoroutine(Stun());
    }

    public override void ExcuteState()
    {
        
    }

    public override void ExitState()
    {
        
    }
}