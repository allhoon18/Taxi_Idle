using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum PlayerStatus
{
    Empty,
    OnBoard
}

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;
    private PassengerSpawner passengerSpawner;

    private Player player;

    public Destination CurrentDestination;

    public Passenger CurrentPassenger;

    public void Init(Player player)
    {
        agent = GetComponent<NavMeshAgent>();
        passengerSpawner = GetComponent<PassengerSpawner>();
        this.player = player;
        agent.speed = player.Stat.Speed;
    }

    public void SetPassenger()
    {
        CurrentPassenger = passengerSpawner.SpawnPassenger();
        CurrentPassenger.IntiPassenger();
        agent.destination = CurrentPassenger.PickUpPoint.position;

        player.Stat.PassedTime = 0;
        player.Stat.ResetCoroutine();
    }

    public void SetDestination()
    {
        CurrentDestination = CurrentPassenger.TargetDestination;
        agent.destination = CurrentDestination.transform.position;
        CurrentPassenger.gameObject.SetActive(false);
    }

    public void SetSign(PlayerStatus playerStatus)
    {
        switch(playerStatus)
        {
            case PlayerStatus.Empty:
                player.IndicatorHandler.SetEmpty();
                break;

            case PlayerStatus.OnBoard:
                player.IndicatorHandler.SetOnBoard();
                break;
        }
    }
}
