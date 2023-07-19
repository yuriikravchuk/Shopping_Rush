using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour 
{
    [SerializeField] private List<State> _states;
    private State _currentState;


    private void Awake()
    {
        //_currentState = FindState<MenuState>();
        _currentState.Enter();
    }

    private void Update() => _currentState.UpdateState();

    public void TrySwitchState<T>(){
        State nextState = FindState<T>();
        if (_currentState.CanTransit(nextState))
            SwitchState(nextState);
    }

    private void SwitchState(State state)
    {
        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    private State FindState<T>() 
        => _states.Find(x => x is T) ?? throw new InvalidOperationException();
}