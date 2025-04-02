using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState _currentState { get; private set; }

    public void Init(PlayerState startState)
    {
        _currentState = startState;
        _currentState.Enter();
    }

    public void ChageState(PlayerState newState)
    {
        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

}
