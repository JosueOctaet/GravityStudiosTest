using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StateMachine
{
    // Dictionary to store the states
    private Dictionary<string, State> states = new Dictionary<string, State>();
    // Variable to store the current state
    private State currentState;

    // Method to register a new state
    public void RegistryNewState(string name, State state)
    {
        states[name] = state;
    }

    // Method to change the current state
    public void ChangeState(string name)
    {
        // If the current state is already equal to the specified state, return
        if (currentState == states[name])
        {
            return;
        }

        // If the states dictionary contains the specified state name...
        if (states.ContainsKey(name))
        {
            // ...if the current state is not null, call its Exit method
            if (currentState != null)
            {
                currentState.Exit();
            }

            // Set the current state to the specified state and call its Enter method
            currentState = states[name];
            currentState.Enter();
        }
    }

    // Method to update the current state
    public void Update()
    {
        if (currentState != null)
        {
            currentState.Execute();
        }
    }

    // Method to get the name of the current state
    public string GetCurrentStateName()
    {
        string name = string.Empty;

        foreach (var state in states)
        {
            if (state.Value == currentState)
            {
                name = state.Key;
            }
        }

        return name;
    }
}

[Serializable]
// Declare an abstract State class with abstract Enter, Execute, and Exit methods
public abstract class State
{
    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}
