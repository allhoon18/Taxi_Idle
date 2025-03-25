using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public PlayerStateMachine stateMachine { get; set; }

    public void Enter();

    public void Exit();

    public void Update();
}
