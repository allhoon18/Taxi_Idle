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
        int fare = stateMachine.Player.Controller.CurrentPassenger.Patience == 0 ?
            stateMachine.Player.Stat.CalculateGold() / 2 : stateMachine.Player.Stat.CalculateGold();
        stateMachine.Player.Stat.AddGold(fare);
    }

    public void Update()
    {
        stateMachine.Player.Stat.UpdateParameter();
    }
}
