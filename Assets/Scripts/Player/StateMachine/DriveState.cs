using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveState : IState
{
    public PlayerStateMachine stateMachine { get; set; }

    public DriveState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public void Enter()
    {
        stateMachine.Player.SetDestination();
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
        
    }
}
