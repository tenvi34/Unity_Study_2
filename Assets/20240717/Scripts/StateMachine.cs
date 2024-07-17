using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum EMyState
{
    IdleMyState,
    MoveMyState,
    StunMyState
}

public interface IMyState   
{
    void EnterState();
    void ExcuteState();
    void ExitState();
}

public abstract class VMyState : MonoBehaviour, IMyState
{
    [NonSerialized]public StateMachine stateMachine;
    public abstract void  EnterState();

    public abstract void ExcuteState();

    public abstract void ExitState();
}

public class StateMachine : MonoBehaviour
{
    [SerializeField] private EMyState defaultState;
    
    private IMyState _currentMyState;
    private Dictionary<EMyState, IMyState> _states = new();

    private void ChangeState_Internal(IMyState newMyState)
    {
        if (_currentMyState != null)
        {
            _currentMyState.ExitState();
        }

        _currentMyState = newMyState;
        _currentMyState.EnterState();
    }

    public void ChangeState(EMyState state)
    {
        ChangeState_Internal(_states[state]);
    }
    
    
    void Start()
    {
        // 1번 이거는 성능이 직접 컴포넌트 가져오는 방식 대비 비싸다.
        VMyState[] stateArray = GetComponents<VMyState>();
        foreach (var state in stateArray)
        {
            state.stateMachine = this;
            EMyState outEnum;
            if (EMyState.TryParse(state.GetType().ToString(), out outEnum))
            {
                _states.Add(outEnum, state);
            }
        }    
        
        // 2번 아레의 방식이 좀 더 비용적으로 저렴하다.
        // _states.Add(EMyState.IdleMyState, GetComponent<IdleMyState>());
        // _states.Add(EMyState.MoveMyState, GetComponent<MoveMyState>());
        // _states.Add(EMyState.StunMyState, GetComponent<StunMyState>());
        
        // DefaultState
        ChangeState(EMyState.IdleMyState);
    }

    
    void Update()
    {
        if (_currentMyState != null)
        {
            _currentMyState.ExcuteState();
        }
    }
}