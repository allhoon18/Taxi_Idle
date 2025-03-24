using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    public PlayerStateMachine stateMachine { get; set; }

    public IdleState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public void Enter()
    {
        stateMachine.Player.Controller.SetPassenger();
        stateMachine.Player.Controller.SetSign(PlayerStatus.Empty);
    }

    public void Exit()
    {

    }

    public void Update()
    {

    }
}
