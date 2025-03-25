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
        stateMachine.Player.Stat.Pay();
    }

    public void Update()
    {
        stateMachine.Player.Stat.UpdateParameter();
    }
}
