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
        stateMachine.Player.IndicatorHandler.SetOnBoard();
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
        stateMachine.Player.UpdateParameter();
    }
}
