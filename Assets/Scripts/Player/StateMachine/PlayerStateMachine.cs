using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public Player Player { get; private set; }

    public IState currentState;

    public IdleState IdleState { get; private set; }
    public DriveState DriveState { get; private set; }

    public PlayerStateMachine(Player player)
    {
        this.Player = player;

        IdleState = new IdleState(this);
        DriveState = new DriveState(this);
    }

    public void ChangeState(IState state)
    {
        if(currentState != null)
            currentState.Exit();
        currentState = state;
        currentState.Enter();
    }

    public void Update()
    {
        if (currentState != null)
            currentState.Update();
    }


}
