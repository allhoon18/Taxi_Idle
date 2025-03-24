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
        stateMachine.Player.Controller.SetDestination();
        stateMachine.Player.Controller.SetSign(PlayerStatus.OnBoard);
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
        stateMachine.Player.Controller.UpdateParameter();
    }
}
