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
        stateMachine.Player.SetPassenger();
        stateMachine.Player.IndicatorHandler.SetEmpty();
    }

    public void Exit()
    {

    }

    public void Update()
    {

    }
}
