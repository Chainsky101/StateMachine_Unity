using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState currentState { get; private set; }

    public void Initialize(PlayerState state)
    {
        currentState = state;
        currentState.Enter();
    }

    public void Exchange(PlayerState state)
    {
        currentState.Exit();
        currentState = state;
        currentState.Enter();
    }
}
